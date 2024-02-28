using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    public PlayerController playerController;
    public SpriteRenderer playerSr;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health<= 0) {
            playerSr.enabled = false;
            playerController.enabled = false;

            SceneManager.LoadSceneAsync(11);
        }
        
    }
}
