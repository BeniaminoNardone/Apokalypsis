using System.Collections;
using System.Collections.Generic;
  
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int damage = 1;

    private void Start()
    {
        // Trova il componente PlayerHealth nel gameObject del giocatore
        playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth non trovato nel giocatore.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Assicurati che il componente PlayerHealth sia stato trovato prima di chiamare TakeDamage
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
