using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    [SerializeField] private ParticleSystem particelleMortePlayer = default;
    public PlayerController playerController;
    public SpriteRenderer playerSr;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            // Disattiva il collider
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            playerSr.enabled = false;
            playerController.enabled = false;
            particelleMortePlayer.transform.position = transform.position; // Imposta la posizione delle particelle sulla posizione del giocatore
            particelleMortePlayer.Play();
            
            //Destroy(gameObject); // Distrugge l'oggetto del giocatore solo se è ancora attivo
        }
    }


}
