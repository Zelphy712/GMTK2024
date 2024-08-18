using UnityEngine;
using UnityEngine.InputSystem;

public class MovingSphere : MonoBehaviour {

    //Editor Variables
	[SerializeField, Range(0f, 100f)]
	float maxSpeed = 10f;
	[SerializeField, Range(0f, 100f)]
	float maxAcceleration = 10f, maxAirAcceleration = 1f;
	[SerializeField, Range(0f, 10f)]
	float jumpHeight = 2f;
	[SerializeField, Range(0, 5)]
	int maxAirJumps = 0;
	[SerializeField, Range(0, 90)]
	float maxGroundAngle = 25f;
    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer sprite;


    //Private Variables
	Rigidbody2D body;
	Vector2 velocity, desiredVelocity;
	Vector2 contactNormal;
	bool desiredJump;
	int groundContactCount;
	bool OnGround => groundContactCount > 0;
	int jumpPhase;
	float minGroundDotProduct;
    private bool facingLeft = false;


    private void Start(){
        // moveAction = InputSystem.action.FindAction("Move");
        // jumpAction = InputSystem.actions.FindAction("Jump");
    }

	void OnValidate () {
		minGroundDotProduct = Mathf.Cos(maxGroundAngle * Mathf.Deg2Rad);
	}

	void Awake () {
		body = GetComponent<Rigidbody2D>();
		OnValidate();
	}

	void Update () {
		Vector2 playerInput;
		if(!PauseMenu.isPaused){
		playerInput.x = moveAction.action.ReadValue<Vector2>().x;
		} else
		{
			playerInput.x = 0;
		}
		playerInput.y = 0;
		playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        // playerInput = moveAction.ReadValue<Vector2>().GetAxis("Horizontal");

		desiredVelocity =
			new Vector2(playerInput.x, playerInput.y) * maxSpeed;
	}

	void FixedUpdate () {
		UpdateState();
		AdjustVelocity();

		if (desiredJump) {
			desiredJump = false;
			Jump();
		}

		body.velocity = velocity;

        //animation transitions
        facingLeft = (body.velocity.x < 0);
        animator.SetFloat("speed",Mathf.Abs(body.velocity.x));
        animator.SetBool("facingLeft", facingLeft);
		animator.SetBool("isJumping",!OnGround);
		ClearState();
	}

	void ClearState () {
		groundContactCount = 0;
		contactNormal = Vector2.zero;
	}

	void UpdateState () {
		velocity = body.velocity;
		if (OnGround) {
			jumpPhase = 0;
			if (groundContactCount > 1) {
				contactNormal.Normalize();
			}
		}
		else {
			contactNormal = Vector2.up;
		}
	}

	void AdjustVelocity () {
		Vector2 xAxis = ProjectOnContactPlane(Vector2.right).normalized;

		float currentX = Vector2.Dot(velocity, xAxis);

		float acceleration = OnGround ? maxAcceleration : maxAirAcceleration;
		float maxSpeedChange = acceleration * Time.deltaTime;

		float newX =
			Mathf.MoveTowards(currentX, desiredVelocity.x, maxSpeedChange);
		velocity += xAxis * (newX - currentX);
	}

	void Jump () {
		if (OnGround || jumpPhase < maxAirJumps) {
			jumpPhase += 1;
			float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
			float alignedSpeed = Vector2.Dot(velocity, contactNormal);
			if (alignedSpeed > 0f) {
				jumpSpeed = Mathf.Max(jumpSpeed - alignedSpeed, 0f);
			}
			velocity += contactNormal * jumpSpeed;
            string [] jumpSounds = {"Jump 1","Jump 2","Jump 3"};
            AudioManager.Instance.PlaySfx(jumpSounds[Random.Range(0,jumpSounds.Length)]);
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		EvaluateCollision(collision);
	}

	void OnCollisionStay2D (Collision2D collision) {
		EvaluateCollision(collision);
	}

    void OnEnable(){
        jumpAction.action.started += requestJump;
    }

    void onDisable(){
        jumpAction.action.started -= requestJump;
    }

    private void requestJump(InputAction.CallbackContext obj){
        if(!PauseMenu.isPaused){ 

		desiredJump = true;
		}
	}

	void EvaluateCollision (Collision2D collision) {
		for (int i = 0; i < collision.contactCount; i++) {
			Vector2 normal = collision.GetContact(i).normal;
			if (normal.y >= minGroundDotProduct) {
				groundContactCount += 1;
				contactNormal += normal;
			}
		}
	}

	Vector2 ProjectOnContactPlane (Vector2 vector) {
		return vector - contactNormal * Vector2.Dot(vector, contactNormal);
	}
}