using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OrbitEnemy : MonoBehaviour
{
   public Rigidbody2D rb;
   public bool orbitting;
   // Start is called before the first frame update
   public Transform target;
   public float orbitDegreesPerSec = 180.0f;
   public Vector3 relativeDistance;
   // Use this for initialization
   private void Awake()
   {
        rb = GetComponent<Rigidbody2D>();
   }
   void Start()
   {
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
       if (orbitting)
    {
        Orbit();
       }
   }
}

