using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject orbiter;
    public GameObject rolling;
    public GameObject enemyBullet;
    
    private bool active;
    private enemy healthSet;
    private float spawnCoolDown;
    private float shootCoolDown;
    //private int spikeCount; initially wanted to allow the boss to create spike enemies up to a limit but decided against it
    public Transform entitySpawn;
    public Transform orbitSpawn;
    private float ran;
    // Start is called before the first frame update
    void Start()
    {
        //spikeCount = 0;
        active = false; //inactive until player enter's collider
        healthSet = gameObject.GetComponent<enemy>();
        healthSet.health = 30; //overrides the normal healthpool of enemies from 3 to 30
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            spawnCoolDown += Time.deltaTime;
            shootCoolDown += Time.deltaTime;
            if (spawnCoolDown > 3.5f)
            {
                spawnCoolDown = 0.0f; //cooldown used for spawning enemies
                ran = Random.Range(0.0f, 10.0f); //random function to decide which enemy to spawn (if any)
                if(ran > 7.0f) //spawn orbit 30% of time
                {
                    OrbitShot();
                }
                if(ran < 7.0f && ran > 3.0f) //spawn rolling enemy 40% of time
                {
                    RollingShot();
                }
                //spawn nothing 30% of time

            }
            if(shootCoolDown > 2.5f)
            {
                shootCoolDown = 0.0f;
                Shoot(); //shoot at player every 2.5 seconds
            }
        }
    }

    //functions used to create orbitters, rolling enemies, and bullet objects
    private void OrbitShot()
    {
        Instantiate(orbiter, orbitSpawn.position, Quaternion.identity);
    }

    private void RollingShot()
    {
        Instantiate(rolling, entitySpawn.position, Quaternion.identity);
    }

    private void Shoot()
    {
        Instantiate(enemyBullet, entitySpawn.position, Quaternion.identity);
    }

    public void Activate()
    {
        active = true;
    }
}
