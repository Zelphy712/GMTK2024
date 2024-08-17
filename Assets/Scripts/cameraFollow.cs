using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Vector3 offset;
    public Transform target;


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x + offset.x,target.position.y + offset.y,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.fixedDeltaTime);
    }
}
