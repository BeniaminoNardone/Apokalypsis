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
    bool isInvincible = false;

    [SerializeField] private ParticleSystem particelleMortePlayer = default;
    public PlayerController playerController;
    public SpriteRenderer playerSr;

    public int HealingPieces = 0;//conta quanto è piena la fiala

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

    IEnumerator Invincibility()
    {
        isInvincible = true;
        for (float i = 0; i < 1.7f; i += 0.1f)
        {
            playerSr.color = new Color(1f, 1f, 1f, Mathf.PingPong(i, 1f));
            yield return new WaitForSeconds(0.1f);
        }
        playerSr.color = new Color(1f, 1f, 1f, 1f);
        isInvincible = false;
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible)
            return;

        _animator.SetTrigger("damageTaken");

        health -= amount;
        audioManager.PlaySFX(audioManager.DannoGesù);

        if (health <= 0)
        {
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            playerSr.enabled = false;
            playerController.enabled = false;
            particelleMortePlayer.transform.position = transform.position;
            particelleMortePlayer.Play();

            StartCoroutine(GameOverDelay());
        }
        else
        {
            StartCoroutine(Invincibility());
        }
    }

    public void Update()
    {
    // Controlla se è stato premuto il pulsante X del DualSense 5 o la barra spaziatrice
        if (Input.GetButtonDown("cura")||Input.GetButtonDown("Jump"))//! Jump è inteso come tasto della barra spaziatrice
        {
            // Chiama la funzione del tuo personaggio
            HealPlayer();
        }
    }
}