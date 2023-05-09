using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDamage : MonoBehaviour
{
    public SpriteRenderer enemySprite;
    public Rigidbody2D enemyBody;
    public GameObject player;
    public Rigidbody2D square;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemySprite = GetComponent<SpriteRenderer>();
        square = player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemy Enemy = enemyBody.GetComponent<enemy>();

        // If and Else if seperation keeps damage types mutually exclusive
        // Bullets deal 1 damage each (plus modifiers from shop which are handled in enemy.cs)
        if (collision.gameObject.tag == "Projectile")
        {
            if (Enemy != null)
                Enemy.TakeDamage(1);
        }

        // When the enemy collides with a spinning player, the enemy takes 3 damage
        // (if the player spins at 10 radians/sec or greater).
        else if (collision.gameObject.tag == "Player" && square.angularVelocity >= 10)
        {
           if (Enemy != null)
                Enemy.TakeDamage(3);
        }
    }
}
