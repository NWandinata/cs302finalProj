using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public SpriteRenderer player;
    public int armor = 0;
    public Rigidbody2D square; //still the player
    private int life = 3;
    [SerializeField] private float fallPoint;

    void Start() //intitializes player and updates stats if player went to the shop
    {
        life = Shop.map["health"] + life;
        armor = Shop.map["armor"] + armor;
        player = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Checks for fall death
        if (gameObject.transform.position.y < fallPoint)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CoinCollector.coins = 0;
            life = 3;
            player.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //checks for taken damage
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Damage_Taken(player);
            square.velocity = new Vector2(square.velocity.x , 5); //when hit, the player moves upward
        }

        if (collision.gameObject.tag == "Enemy" && square.angularVelocity < 10)
            Damage_Taken(player);
    }

    public void Damage_Taken(SpriteRenderer play) //the color of the player reflects their health
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

        // Player respawns
        else if (life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CoinCollector.coins = 0;
            life = 3;
            play.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

}