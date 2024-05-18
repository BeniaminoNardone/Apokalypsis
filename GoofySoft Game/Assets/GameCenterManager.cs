using UnityEngine;
using UnityEngine.SocialPlatforms;
using System;

public class GameCenterManager : MonoBehaviour
{
    private bool isAuthenticated = false;

    void Start()
    {
        // Inizializza il Game Center
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                isAuthenticated = true;
                Debug.Log("Game Center authenticated!");
            }
            else
            {
                isAuthenticated = false;
                Debug.LogWarning("Failed to authenticate Game Center.");
            }
        });
    }

    // Metodo per visualizzare la leaderboard
    public void ShowLeaderboard()
    {
        if (isAuthenticated)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            Debug.LogWarning("Cannot show leaderboard. User not authenticated.");
        }
    }

    // Metodo per inviare un punteggio alla leaderboard
    public void ReportScore(long score, string leaderboardID)
    {
        if (isAuthenticated)
        {
            Social.ReportScore(score, leaderboardID, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("Score reported successfully to leaderboard!");
                }
                else
                {
                    Debug.LogWarning("Failed to report score to leaderboard.");
                }
            });
        }
        else
        {
            Debug.LogWarning("Cannot report score. User not authenticated.");
        }
    }

    // Metodo per aprire la pagina del Game Center
    public void OpenGameCenterPage()
    {
        Application.OpenURL("gamecenter:");
    }
}
