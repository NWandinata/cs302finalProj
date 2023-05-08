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

    // Start is called before the first frame update
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    //update after hit
    private void Update()
    {
        if (hit) return;
        float travelSpeed = speed * Time.deltaTime * direction;
        transform.Translate(travelSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 4) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) //when the enemy gets hit
    {
        hit = true;
        enemy Enemy = hitInfo.GetComponent<enemy>();

        if (Enemy != null)
        {
            Enemy.TakeDamage(damage);
        }

        boxCollider.enabled = false;
        gameObject.SetActive(false);
    }
    //sets bullet direction
    public void SetDirection(float bulletDirection)
    {
        lifetime = 0;
        direction = bulletDirection;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

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