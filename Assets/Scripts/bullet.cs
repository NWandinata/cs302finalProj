using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //initalize 
    public float speed = 20f;
    private float direction;
    private bool hit;
    public int damage = 1;
    private float lifetime;
    private BoxCollider2D boxCollider;

    // Gives the bullet collision
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    //update after hit
    private void Update()
    {
        // Speed and lifetime isn't calculated for a bullet that has collided since it will become inactive
        if (hit) return;

        float travelSpeed = speed * Time.deltaTime * direction;
        transform.Translate(travelSpeed, 0, 0);

        // Bullet will become inactive after 4 seconds of travel without collision
        lifetime += Time.deltaTime;
        if (lifetime > 4) gameObject.SetActive(false);
    }

    // Detects collision with any object
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        hit = true;
        enemy Enemy = hitInfo.GetComponent<enemy>();

        // Bullets will damage enemies
        if (Enemy != null)
        {
            Enemy.TakeDamage(damage);
        }

        // Bullet becomes inactive and its collision disappears upon hit
        boxCollider.enabled = false;
        gameObject.SetActive(false);
    }
<<<<<<< Updated upstream
    //sets bullet direction
=======

    // Bullets will always travel right (forward from player)
>>>>>>> Stashed changes
    public void SetDirection(float bulletDirection)
    {
        // Sets the bullet as an active object
        lifetime = 0;
        direction = bulletDirection;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        // Makes bullet travel in front of the player
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != bulletDirection)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}