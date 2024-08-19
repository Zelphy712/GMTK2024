using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectileRb;
    public float speed;
    public float launchAngle;
    public float projectileLife;
    public float projectileCount;
    public float projectileRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
        projectileRb = GetComponent<Rigidbody2D>();

        float launchingAngleRad = launchAngle * Mathf.Deg2Rad;

        float initialVelocityX = speed * Mathf.Cos(launchingAngleRad);
        float initialVelocityY = speed * Mathf.Sin(launchingAngleRad);

        projectileRb.velocity = new Vector2(initialVelocityX,initialVelocityY);

    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0){
            Destroy(gameObject);
        }
        
    }

    private void FixedUpdate(){
        // xy translation
        

        float rotationSpeed = projectileRotationSpeed;
        float rotationAngle = (-1) * rotationSpeed * Time.fixedDeltaTime;
        projectileRb.rotation += rotationAngle;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Weak Point")){
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
