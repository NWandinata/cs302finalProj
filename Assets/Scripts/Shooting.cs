using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    //press f to fire
    public Transform firePoint;
    public GameObject bulletPrefeb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefeb, firePoint.position, firePoint.rotation);
    }
}
