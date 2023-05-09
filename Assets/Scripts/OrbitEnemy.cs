using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OrbitEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool orbitting = false;
    public int enSpeed = 2; //adjustable speed val

    private Transform target;
    public float orbitDegreesPerSec = 180.0f; //adjustable rotational speed val
    public Vector3 relativeDistance;
    private GameObject player;
   // Use this for initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        relativeDistance = transform.position - target.position; //find distance between player and orbitter
        target = player.transform;
    }

    void Orbit()
    {
        if (target != null)
        {
            // Keep us at the last known relative position
            transform.position = target.position + relativeDistance; //follows target position
            transform.RotateAround(target.position, Vector3.forward, orbitDegreesPerSec * Time.deltaTime); //rotates the orbitter arround the target 
            // Reset relative position after rotate
            relativeDistance = transform.position - target.position; //adjust relative distance
        }
    }
    void Update()
    {
        target = player.transform; // follow target
        float distance = Vector2.Distance(transform.position, player.transform.position); //measure total distance
        if (distance < 4) //when they are close enough, follow target
        {
            orbitting = true;
        }

        if (orbitting)
        {
            Orbit();
        }
        else //otherwise, update relativeDistance and move to the right
        {
            relativeDistance = transform.position - target.position;
            rb.velocity = transform.right * enSpeed;
        }
   }
}

