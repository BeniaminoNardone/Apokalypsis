using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fetopiccolo : MonoBehaviour
{
    public int maxHealth = 1;
    int currentHealth;
    int damage = 1;
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
        Debug.Log("enemy died");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
