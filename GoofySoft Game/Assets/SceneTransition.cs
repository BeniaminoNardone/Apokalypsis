using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image img;
    public string sceneToLoad;
    public float transitionTime = 1f;

    void Start()
    {
        // Inizia con un'immagine trasparente
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
    }

    public void TransitionToScene()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        // Dissolvenza in entrata
        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            float normalizedTime = t / transitionTime;
            // Imposta l'alfa dell'immagine per creare l'effetto di dissolvenza
            img.color = new Color(img.color.r, img.color.g, img.color.b, normalizedTime);
            yield return null;
        }

        // Carica la scena
        SceneManager.LoadScene(sceneToLoad);
    }
}
