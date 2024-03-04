using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestoreScene : MonoBehaviour
{
      

    public void RestartButton()
    {
        SceneManager.LoadScene("ScenaDiGioco");
        ScoreManager.azzeraScore();
    }


    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
        ScoreManager.azzeraScore();

    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadSceneAsync("Credits");
    }

    public void Trofei()
    {
        SceneManager.LoadSceneAsync("Trofei");
    }
}
