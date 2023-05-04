using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDamage : MonoBehaviour
{
    public SpriteRenderer enemySprite;
    public Rigidbody2D enemyBody;
    public GameObject player;
    public Rigidbody2D square;

    // Start is called before the first frame update
    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        square = player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && square.angularVelocity >= 12)
        {
            Debug.Log("Spin Kill");
            enemy Enemy = enemyBody.GetComponent<enemy>();

            if (Enemy != null)
            {
                Enemy.TakeDamage(3);
            }

            Destroy(gameObject);
        }
    }
}
