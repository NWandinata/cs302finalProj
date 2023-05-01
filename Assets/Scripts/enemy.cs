using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public static int health = 3;

    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health =health-damage-Shop.map["damage"];

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
