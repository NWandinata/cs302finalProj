using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public SpriteRenderer player;
    //private List<Color> colors;

    public int armor = 0;
    public Rigidbody2D square; //still the player
    private int life = 3;


    // Start is called before the first frame update
    void Start() //make an obstacle to hit
    {
        life = Shop.health + life;
        armor = Shop.armor + armor;
        player = GetComponent<SpriteRenderer>();
        /*colors = new List<Color>();
        colors.Add(Color.green);
        colors.Add(Color.yellow);
        colors.Add(Color.red);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Obstacle")
        {
            Damage_Taken(player);
            square.velocity = new Vector2(square.velocity.x , 8);
        }

        if (collision.gameObject.tag == "Enemy" && square.angularVelocity < 3)
        {
            Damage_Taken(player);
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
            //Destroy(play); //dies

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                //respawn
                SceneManager.LoadScene("Level1");
            }

            life = 3;
            play.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

}