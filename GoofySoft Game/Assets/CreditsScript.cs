using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    public Text testoDaAttivare; // Riferimento al componente Text da attivare

    // Funzione per attivare il testo con un testo specifico
    public void AttivaTesto(string nuovoTesto)
    {
        Debug.Log("1!!");
        // Assicurati che il riferimento al testo da attivare non sia nullo
        if (testoDaAttivare != null)
        {
            Debug.Log("2!!");

            // Attiva il testo e imposta il nuovo testo
            testoDaAttivare.gameObject.SetActive(true);
            testoDaAttivare.text = nuovoTesto;
        }
        else
        {
            Debug.LogError("Riferimento al testo non impostato!");
        }
    }
}
