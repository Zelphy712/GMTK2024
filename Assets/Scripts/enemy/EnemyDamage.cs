using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public playerState playerState;
    // public PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
        {
            playerState playerState = collision.gameObject.GetComponent<playerState>();
            if (playerState != null){
                playerState.TakeDamage(damage);
            }
            
        }
    }

}