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
        enemySprite = GetComponent<SpriteRenderer>();
        square = player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the enemy collides with a spinning player, the enemy takes 3 damage
        // (if the player spins at 10 radians/sec or greater).
        if (collision.gameObject.tag == "Player" && square.angularVelocity >= 10)
        {
            enemy Enemy = enemyBody.GetComponent<enemy>();

            if (Enemy != null)
            {
                Enemy.TakeDamage(3);
            }

            // All enemies have 3 hp, so this would be an instant kill
            Destroy(gameObject);
        }
    }
}
