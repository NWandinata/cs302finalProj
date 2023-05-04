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

    void Start()
    {
        life = Shop.map["health"] + life;
        armor = Shop.map["armor"] + armor;
        player = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check for fall death
        if (gameObject.transform.position.y < fallPoint)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CoinCollector.coins = 0;
            life = 3;
            player.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Damage_Taken(player);
            square.velocity = new Vector2(square.velocity.x , 5);
        }

        if (collision.gameObject.tag == "Enemy" && square.angularVelocity < 12)
            Damage_Taken(player);
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

        // Respawn
        else if (life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CoinCollector.coins = 0;
            life = 3;
            play.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

}