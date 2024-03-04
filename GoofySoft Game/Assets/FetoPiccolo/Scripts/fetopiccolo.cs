using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fetopiccolo : MonoBehaviour
{
    monsterSpawner Spawner;
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

    // Start is called before the first frame update
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

        this.enabled = false;
        movimento.enabled = false;
        _collider.enabled = false;
        Debug.Log("enemy died");

        ScoreManager.scoreCount += 10;

       if(Spawner != null) Spawner.currentMonster.Remove(this.gameObject);

        // Attiva la coroutine per distruggere il GameObject dopo l'animazione di morte
        StartCoroutine(DestroyAfterAnimation());

        if (Random.value <= dropChance)
        {
            DropCollectible();
        }
    }
    void DropCollectible()
    {
        Instantiate(Coin, transform.position, Quaternion.identity);
    }


    public void SetSpawner(monsterSpawner _spawner) {
        Spawner = _spawner;
    }

 

    IEnumerator DestroyAfterAnimation()
    {

        gestoreSuoniMorte();

        // Attendi finché l'animazione di morte non è completata
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

        // Distruggi il GameObject
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }



    // Update is called once per frame
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

    }

}
