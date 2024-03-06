using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicIntro : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        // Ottieni l'AudioSource associato a questo GameObject
        audioSource = GetComponent<AudioSource>();

        // Controlla se c'è già un'altra istanza di questo GameObject con lo stesso tag
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MusicIntroduction");
        if (musicObj.Length > 1)
        {
            // Se c'è già un'altra istanza, distruggi questa
            Destroy(this.gameObject);
        }

        // Non distruggere questo oggetto durante il cambio di scena
        DontDestroyOnLoad(this.gameObject);

        // Aggiungi un listener per il cambio di scena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Rimuovi il listener quando l'oggetto viene distrutto
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Controlla se la scena caricata è la scena con indice 10
        if (scene.buildIndex == 10)
        {
            // Interrompi l'audio quando viene caricata la scena con indice 10
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }
}