using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
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
}
