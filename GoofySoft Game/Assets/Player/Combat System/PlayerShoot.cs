using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator _animator;
    public Vector3 offsety;
    public float delay = 0.05f; // Tempo di attesa in secondi

    private void Start()
    {

         offsety = new Vector3(0f, 3f, 0f);

    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = (_joystick.Horizontal != 0) ? _joystick.Horizontal : Input.GetAxis("Horizontal");
        float verticalInput = (_joystick.Vertical != 0) ? _joystick.Vertical : Input.GetAxis("Vertical");

        horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);
        verticalInput = Mathf.Clamp(verticalInput, -1f, 1f);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, -angle);
        }
    }

    public void Shoot()
    {
        _animator.SetTrigger("IsDartAttack");
        StartCoroutine(InstantiateBulletWithDelay());
    }

    private IEnumerator InstantiateBulletWithDelay()
    {
        yield return new WaitForSeconds(delay);

        // Calcola l'angolo Z corretto per mantenere il proiettile parallelo al terreno
        float angle = Mathf.Atan2(firePoint.right.y, firePoint.right.x) * Mathf.Rad2Deg;

        // Istanzia il proiettile con l'offset
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + offsety, Quaternion.Euler(0, angle, 0));
    }


}
