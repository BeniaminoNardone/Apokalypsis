using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
    }
}
