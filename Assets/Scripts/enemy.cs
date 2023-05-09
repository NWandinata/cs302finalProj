using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 3;

    public GameObject deathEffect;

    public void TakeDamage(int damage)//damage taken by enemies
    {
        health =health-damage-Shop.map["damage"];

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
