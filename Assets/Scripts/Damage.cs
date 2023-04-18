using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //public Renderer change;
    public SpriteRenderer player;
    [SerializeField] private Color[] colors; //yellow and red

    // Start is called before the first frame update
    void Start() //make an obstacle to hit
    {
        player.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        //if a certain button is hit (aka. player gets hit), call Damage_Taken
    }

    public void Damage_Taken()
    {

    }
}
