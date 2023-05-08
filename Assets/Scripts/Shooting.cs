using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;

    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity; // Allows player to attack immediately when level loads

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Press the "F" key to fire if cooldown has passed and updates cooldown timer every frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && cooldownTimer > attackCooldown)
            Shoot();

        cooldownTimer += Time.deltaTime;
    }

    // Reset cooldown upon each shot
    private void Shoot()
    {
        cooldownTimer = 0;

        // Bullets will always travel forward
        bullets[FindBullet()].transform.position = firePoint.position;
        bullets[FindBullet()].GetComponent<bullet>().SetDirection((Mathf.Sign(transform.localScale.x)));
    }

    // Loads in the next bullet in the array based on index
    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}