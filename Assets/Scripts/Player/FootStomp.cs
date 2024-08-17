using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStomp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weak Point"))
        {
            Destroy(collision.gameObject);
        }
    }


}
