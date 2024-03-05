using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject UI;
    public void Pause() {
        PausePanel.SetActive(true);
        UI.SetActive(false);
        Time.timeScale = 0;
    }

    public void Continue() {
        UI.SetActive(true);
        PausePanel.SetActive(false);
       Time.timeScale = 1;
    }
}