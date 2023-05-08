using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Damage playerHealth;
    private SpriteRenderer playerSprite;
    public float bulletSpeed;
    private float airTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Damage>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        Vector3 dir = player.transform.position - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * bulletSpeed;

        float rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        airTime += Time.deltaTime;
        if(airTime > 3)
        {
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var go = hitInfo.gameObject;
        if (go == player)
        {
            playerHealth.Damage_Taken(playerSprite);
            Destroy(gameObject);

        }
    }
}
