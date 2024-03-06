using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject UI;
    public Button pauseButton;

    private void Start()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(HideButton); // Aggiungi un listener per nascondere il pulsante
    }

    private void HideButton()
    {
        pauseButton.gameObject.SetActive(false);
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        UI.SetActive(false);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        UI.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Aggiungi questo metodo per far riapparire il pulsante quando premi "Play"
    public void ShowButton()
    {
        pauseButton.gameObject.SetActive(true);
    }
}
