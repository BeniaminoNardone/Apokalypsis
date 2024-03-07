using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public Animator _animator;
    AudioManager audioManager;


    [SerializeField] private ParticleSystem particelleMortePlayer = default;
    public PlayerController playerController;
    public SpriteRenderer playerSr;


    public int HealingPieces = 0;//conta quanto è piena la fiala
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }


    public void HealPlayer()
    {
        if (HealingPieces >= 3 && health!=maxHealth)//se ho una fiala completa
        {
            audioManager.PlaySFX(audioManager.Beve);

            health++;
            HealingPieces = 0;
        }

    }

    public void IncrementHealtPiece()
    {
        HealingPieces++;
        if (HealingPieces == 3)
        {
            audioManager.PlaySFX(audioManager.BoccettaPiena);

        }
        Debug.Log(" HealingPieces++ ");
    }

    public int GetHealtPiece()
    {
        return HealingPieces;
    }

     private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    public void TakeDamage(int amount)
    {
       _animator.SetTrigger("damageTaken");

        health -= amount;
        audioManager.PlaySFX(audioManager.DannoGesù);
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



            SceneManager.LoadScene("GameOver");

            //Destroy(gameObject); // Distrugge l'oggetto del giocatore solo se è ancora attivo
        }



    }


    public void Update()
    {
        // Controlla se è stato premuto il pulsante X del DualSense 5
        if (Input.GetButtonDown("cura"))
        {
            // Chiama la funzione del tuo personaggio
            HealPlayer();
        }
    }


}
