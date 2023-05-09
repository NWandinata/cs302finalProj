using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Mvt : MonoBehaviour
{
    //health is inside a script called enemy
    public int enSpeed = 3;
    public Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = transform.right * enSpeed; //simple function that moves enemy to the right
    }
}
