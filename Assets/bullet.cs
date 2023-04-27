using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) //when the enemy gets hit
    {
        enemy Enemy = hitInfo.GetComponent<enemy>();

        if(Enemy != null)
        {
            Enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

}
