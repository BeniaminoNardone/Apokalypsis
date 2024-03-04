using System.Collections;
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

        movimento.enabled = false;
         Debug.Log("enemy died");

        ScoreManager.scoreCount += 10;

        if (Spawner != null) Spawner.currentMonster.Remove(this.gameObject);

        StartCoroutine(DestroyAfterAnimation());

        if (Random.value <= dropChance)
        {
            DropCollectible();
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
        Debug.Log("Starting destruction coroutine...");
        // Attendi finché l'animazione di morte non è completata
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

        Debug.Log("Animation completed, destroying GameObject...");
        // Distruggi il GameObject
    //    Instantiate(bloodParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update()
    {

    }
}
