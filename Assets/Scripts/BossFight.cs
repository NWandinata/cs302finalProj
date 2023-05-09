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
        active = false;
        healthSet = gameObject.GetComponent<enemy>();
        healthSet.health = 30;
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
                spawnCoolDown = 0.0f;
                ran = Random.Range(0.0f, 10.0f);
                if(ran > 7.0f)
                {
                    OrbitShot();
                }
                if(ran < 7.0f && ran > 3.0f)
                {
                    RollingShot();
                }

            }
            if(shootCoolDown > 2.5f)
            {
                shootCoolDown = 0.0f;
                Shoot();
            }
        }
    }

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
