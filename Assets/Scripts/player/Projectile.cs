using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed;
    public float projectileLife;
    public float projectileCount;
    public float projectileRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
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
        projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);

        float rotationSpeed = projectileRotationSpeed;
        float rotationAngle = (-1) * rotationSpeed * Time.fixedDeltaTime;
        projectileRb.rotation += rotationAngle;
    }
}
