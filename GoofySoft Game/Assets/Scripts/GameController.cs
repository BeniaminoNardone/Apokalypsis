using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    int maxPLatform = 0;

    public void GameOver()
    {
        GameOverScreen.Setup(maxPLatform);
    }
    private void Awake()
    {
        
    }
     void Start()
    {
        
    }

}
