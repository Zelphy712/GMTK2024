using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
public int maxHealth = 10;
public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

public void TakeDamage(int damage)
    {
        print("player damaged");
        health -= damage;
        if (health <= 0)
        {
            print("Player is dead");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}
