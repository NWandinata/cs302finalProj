using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OrbitEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool orbitting = false;
    public int enSpeed = 2;
    // Start is called before the first frame update
    public Transform target;
    public float orbitDegreesPerSec = 180.0f;
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
       relativeDistance = transform.position - target.position;
    }

    void Orbit()
    {
        if (target != null)
        {
            // Keep us at the last known relative position
            transform.position = target.position + relativeDistance;
            transform.RotateAround(target.position, Vector3.forward, orbitDegreesPerSec * Time.deltaTime);
            // Reset relative position after rotate
            relativeDistance = transform.position - target.position;
        }
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 4)
        {
            orbitting = true;
        }

        if (orbitting)
        {
            Orbit();
        }
        else
        {
            relativeDistance = transform.position - target.position;
            rb.velocity = transform.right * enSpeed;
        }
   }
}

