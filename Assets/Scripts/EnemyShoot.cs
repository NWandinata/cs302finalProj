using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    [SerializeField] GameObject orbitter;
    OrbitEnemy em; //enemy movement
    public Transform bulletPos;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        em = orbitter.GetComponent<OrbitEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (em.orbitting)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                Shoot();

            }
        }
    }

    void Shoot()
    {
        Instantiate(enemyBullet, bulletPos.position, Quaternion.identity);
    }
}

