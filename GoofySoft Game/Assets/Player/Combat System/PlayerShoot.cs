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
    private float disableShootingTimer; // Timer per disabilitare il tasto di sparo

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShootingEnabled)
        {
            // Controlla se è stato premuto il pulsante X del DualSense 5, o il tasto I della tastiera e se il cooldown è passato
                if ((Input.GetButtonDown("AttaccoDart") || Input.touchCount > 0) && Time.time - lastDartTime >= dartCooldown)
            {
                // Chiama la funzione del tuo personaggio
                Shoot();
                // Aggiorna il tempo dell'ultimo dardo sparato
                lastDartTime = Time.time;
            }
        }

        // Controlla se il tasto di sparo è stato disabilitato
        if (!isShootingEnabled)
        {
            // Aggiorna il timer per disabilitare il tasto di sparo
            disableShootingTimer -= Time.deltaTime;
            // Se il timer è scaduto, riabilita il tasto di sparo
            if (disableShootingTimer <= 0)
            {
                isShootingEnabled = true;
            }
        }

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
        audioManager.PlaySFX(audioManager.LancioDelDardo);

        // Calcola l'angolo Z corretto per mantenere il proiettile parallelo al terreno
        float angle = Mathf.Atan2(firePoint.right.y, firePoint.right.x) * Mathf.Rad2Deg;
        float offsetx = 0;
        offsetx = angle <= 90 ? 3.2f : -3.2f;

        offset = new Vector3(offsetx, 3.2f, 0f);
        // Istanzia il proiettile con l'offset
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + offset, Quaternion.Euler(0, angle, 0));

        // Disabilita il tasto di sparo per 3 secondi
        isShootingEnabled = false;
        disableShootingTimer = 1f;
    }
}