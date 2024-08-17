using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public Transform[] waypoints;
    public float speed;
    public int destination;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length > 0)
        {
            if (destination == 0)
            {
                // print("destination " +  destination);
                transform.position = Vector2.MoveTowards(transform.position, waypoints[0].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, waypoints[0].position) < 0.1f)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    destination = 1;
                }
            }
            if (destination == 1)
            {
                // print("destination " +  destination);
                transform.position = Vector2.MoveTowards(transform.position, waypoints[1].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, waypoints[1].position) < 0.1f)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    destination = 0;
                }
            }
        }
    }
}
