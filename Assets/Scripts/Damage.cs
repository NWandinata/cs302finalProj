using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    public SpriteRenderer player;
    public int life = 3;


    // Start is called before the first frame update
    void Start() //make an obstacle to hit
    {
        player = GetComponent<SpriteRenderer>(); //changes color
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collider2D collider = collision.collider;
        if (collision.gameObject.name == "Obstacle")
        {
            Damage_Taken(player);

            //knockback

            //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * knockbackForce, rb.velocity.y);
        }
    }

    public void Damage_Taken(SpriteRenderer play)
    {
        life--;

        if (life == 2)
        {
            play.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        else if (life == 1)
        {
            play.GetComponent<SpriteRenderer>().color = Color.red;
        }

        else if (life <= 0)
        {
            Destroy(play);
            //maybe restart level
        }
    }

}