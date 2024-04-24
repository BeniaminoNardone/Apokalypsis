

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
    public Vector3 offset;
    AudioManager audioManager;

    public float dartCooldown = 0.5f; // Tempo di cooldown tra un dardo e l'altro
    private float lastDartTime; // Tempo dell'ultimo dardo sparato

    private bool isShootingEnabled = true; // Indica se il tasto di sparo è abilitato

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("AttaccoDart")){
        Shoot();
        }
        float horizontalInput = (_joystick.Horizontal != 0) ? _joystick.Horizontal : Input.GetAxis("Horizontal");
        float verticalInput = (_joystick.Vertical != 0) ? _joystick.Vertical : Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, -angle);
        }
    }

    public void Shoot()
    {
        // Verifica se il tasto di sparo è abilitato e se il cooldown è passato
        if (isShootingEnabled && Time.time - lastDartTime >= dartCooldown)
        {
            // Chiama la funzione del tuo personaggio
            _animator.SetTrigger("IsDartAttack");
           // audioManager.PlaySFX(audioManager.LancioDelDardo);//TODO: cambiare suono

            // Calcola l'angolo Z corretto per mantenere il proiettile parallelo al terreno
            float angle = Mathf.Atan2(firePoint.right.y, firePoint.right.x) * Mathf.Rad2Deg;
            float offsetx = 0;
            offsetx = angle <= 90 ? 3.2f : -3.2f;

            offset = new Vector3(offsetx, 3.2f, 0f);
            // Istanzia il proiettile con l'offset
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position + offset, Quaternion.Euler(0, angle, 0));

            // Disabilita il tasto di sparo per il tempo di cooldown
            isShootingEnabled = false;

            // Aggiorna il tempo dell'ultimo dardo sparato
            lastDartTime = Time.time;

            // Avvia il coroutine per riabilitare il tasto di sparo dopo il cooldown
            StartCoroutine(EnableShootingAfterCooldown());
        }
    }

    IEnumerator EnableShootingAfterCooldown()
    {
        // Attendi il tempo di cooldown prima di riabilitare il tasto di sparo
        yield return new WaitForSeconds(dartCooldown);

        // Riabilita il tasto di sparo
        isShootingEnabled = true;
    }
}
