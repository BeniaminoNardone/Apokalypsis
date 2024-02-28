using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fetopiccolo : MonoBehaviour
{
    public Animator _animator;
    public movementAI movimento;
    public BoxCollider _collider;
    public int maxHealth = 1;
    int currentHealth;
    int damage = 1;
    public ParticleSystem bloodParticles;

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

        // Attiva la coroutine per distruggere il GameObject dopo l'animazione di morte
        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        // Attendi finché l'animazione di morte non è completata
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

        // Distruggi il GameObject
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
