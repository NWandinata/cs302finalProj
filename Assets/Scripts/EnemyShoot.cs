using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private Transform projSpawnPos;

    [SerializeField]
    private float minShootWaitTime = 1f, maxShootWaitTime = 3f;

    private float waitTime;

    [SerializeField]
    private List<EnemyLightProjectile> lightProjectiles;

    private bool canShoot;
    private int projIndex;

    [SerializeField]
    private int initialProjCount = 2;

    private Transform playerTransform;

    private Vector3 direction;
    private float angle;

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        for (int i = 0; i < initialProjCount; i++)
        {
            // while instantiating the bullet game object also get the SpiderBullet component
            lightProjectiles.Add(Instantiate(projectile).GetComponent<EnemyLightProjectile>());
            lightProjectiles[i].gameObject.SetActive(false);
        }

        waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
    }

    private void Update()
    {
        FacePlayersDirection();
    }

    void Shoot()
    {
        canShoot = true;
        projIndex = 0;

        while (canShoot)
        {
            if (!lightProjectiles[projIndex].gameObject.activeInHierarchy)
            {
                lightProjectiles[projIndex].gameObject.SetActive(true);

                // set the rotation of the bullet to the rotation of the spider(parent game object)
                lightProjectiles[projIndex].transform.rotation = transform.rotation;
                lightProjectiles[projIndex].transform.position = projSpawnPos.position;

                // call the shoot bullet function to shoot the bullet
                lightProjectiles[projIndex].ShootBullet(transform.up);

                canShoot = false;
            }
            else
            {
                projIndex++;
            }

            if (projIndex == lightProjectiles.Count)
            {
                // while
                lightProjectiles.Add(Instantiate(projectile, projSpawnPos.position, transform.rotation).GetComponent<EnemyLightProjectile>());

                // access the bullet we just created by subtracting 1 from
                // the total bullet count in the list
                lightProjectiles[lightProjectiles.Count - 1].ShootBullet(transform.up);

                canShoot = false;
            }
        }
    }

    void FacePlayersDirection()
    {
        direction = playerTransform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);

        if (Time.time > waitTime)
        {
            waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
            Shoot();
        }
    }

} // class