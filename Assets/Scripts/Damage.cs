using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public SpriteRenderer player;
    //private List<Color> colors;
    public int life = 3;

    // Start is called before the first frame update
    void Start() //make an obstacle to hit
    {
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