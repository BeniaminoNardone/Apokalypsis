using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fiala : MonoBehaviour
{
    public Button button; // Riferimento al bottone
    public Sprite[] sprites; // Array di sprite possibili
    private int riempimentoFiala = 0; // Indice corrente nell'array



    public PlayerHealth _playerHealth;


    void Start()
    {
  
        // Assicurati che il riferimento al bottone sia impostato correttamente
        if (button == null)
        {
            Debug.LogError("Button reference not set.");
            return;
        }

       
    }


    private void Update()
    {

        riempimentoFiala= _playerHealth.HealingPieces;
        ChangeSprite();
    }


    void ChangeSprite()
    {
        // Ottieni il componente Image associato al bottone
        Image buttonImage = button.GetComponent<Image>();

        // Verifica che il componente Image esista
        if (buttonImage != null)
        {
            if (riempimentoFiala <= 3)
            {
                // Assegna il nuovo sprite al componente Image
                buttonImage.sprite = sprites[riempimentoFiala];
            }
        }
        else
        {
            Debug.LogError("Button Image component not found.");
        }
    }
}
