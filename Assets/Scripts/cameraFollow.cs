using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Vector3 offset;
    public Transform target;
    [SerializeField, Range(0f, 100f)]
    float maxDistance = 10f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x + offset.x,target.position.y + offset.y,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.fixedDeltaTime);




        // distance = Vector2.Distance(transform.position, (target.position + offset));
        // if(distance > maxDistance){
        //     newPos = transform.position - (target.position + offset);
        //     newPos = newPos.normalized * maxDistance + target.position + offset;
        //     transform.position = newPos;
        // }
    }
}
