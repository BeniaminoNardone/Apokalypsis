using System.Collections;
using UnityEngine;

public class fetopiccolo : MonoBehaviour
{
    monsterSpawner Spawner;
    public float animationLenghtInfo;
    public Animator _animator;
    public movementAI movimento;
    public BoxCollider _collider;
    public int maxHealth = 1;
    int currentHealth;
    int damage = 1;
    public ParticleSystem bloodParticles;
    public GameObject Coin;
    public float dropChance = 0.5f;
    AudioManager audioManager;
    public string TipoNemico;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        _animator.SetTrigger("isDied");
        if(movimento!=null) movimento.enabled = false;
         Debug.Log("enemy died");

        ScoreManager.scoreCount += 10;

        if (Spawner != null) Spawner.currentMonster.Remove(this.gameObject);

        StartCoroutine(DestroyAfterAnimation());
        if (Coin != null) {
            if (Random.value <= dropChance)
            {
                DropCollectible();
            }
        }
    
    }

    void DropCollectible()
    {
        Instantiate(Coin, transform.position, Quaternion.Euler(33f, 0f, 0f));
    }

    public void SetSpawner(monsterSpawner _spawner)
    {
        Spawner = _spawner;
    }
    IEnumerator DestroyAfterAnimation()
    {
        gestoreSuoniMorte();

        // Ottieni la lunghezza dell'animazione corrente
        float animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
        if (animationLenghtInfo!= 0){
            // Attendi finché l'animazione di morte non è completata
            yield return new WaitForSeconds(animationLenghtInfo);
        }
        else
        {
            // Attendi finché l'animazione di morte non è completata
            yield return new WaitForSeconds(animationLength);
        }
        Debug.Log("Animation length: " + animationLength);

        Debug.Log("Starting destruction coroutine...");

    

        Debug.Log("Animation completed, destroying GameObject...");
        Destroy(gameObject);
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }


    void Update()
    {

    }
    void gestoreSuoniMorte()
    {
        if (TipoNemico == "fetoPiccolo")
        {
            audioManager.PlaySFX(audioManager.MorteBabyFeto);
        }
        if (TipoNemico == "fetone")
        {
            audioManager.PlaySFX(audioManager.MorteFetone);
        }
        if (TipoNemico == "fetostrello")
        {
            audioManager.PlaySFX(audioManager.MorteFetostrello);
        }
        if (TipoNemico == "bobbio")
        {
            audioManager.PlaySFX(audioManager.EsplosioneBobbio);
        }
        if (TipoNemico == "goldenFetoPiccolo")
        {
            audioManager.PlaySFX(audioManager.GoldenFetoPiccolo);
        }
    }


}
