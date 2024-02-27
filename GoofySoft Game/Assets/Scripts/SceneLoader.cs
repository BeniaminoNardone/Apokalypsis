using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator crossFade;

    void Start()
    {
        // Controlla se è la prima volta che il gioco viene avviato
        if (IsFirstTime())
        {
            // Se è la prima volta, mostra la tua scena di riferimento
            StartCoroutine(LoadSceneWithCrossFade(1)); // Assumendo che la scena di riferimento sia alla buildIndex 1
            SetFirstTime(false);
        }
    }

    void Update()
    {
        // Puoi mantenere il codice esistente per caricare la prossima scena con un clic del mouse
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadSceneWithCrossFade(currentSceneIndex + 1));
    }

    IEnumerator LoadSceneWithCrossFade(int sceneIndex)
    {
        crossFade.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }

    private bool IsFirstTime()
    {
        // Leggi lo stato dalla PlayerPrefs
        return PlayerPrefs.GetInt("IsFirstTime", 1) == 1;
    }

    private void SetFirstTime(bool value)
    {
        // Imposta lo stato nella PlayerPrefs
        PlayerPrefs.SetInt("IsFirstTime", value ? 1 : 0);
        PlayerPrefs.Save();
    }
}