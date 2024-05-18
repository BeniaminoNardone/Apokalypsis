using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
        public GameCenterManager gameCenterManager;

    public Text scoreText;
    public Text hiScoreText;
    public static int scoreCount;
    public static int hiScoreCount;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore1"))
        {
            hiScoreCount = PlayerPrefs.GetInt("HighScore1");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreCount > hiScoreCount) 
        {

            hiScoreCount = scoreCount;
            PlayerPrefs.SetInt("HighScore1", hiScoreCount);

            gameCenterManager.ReportScore(hiScoreCount, "Souls_Collected");


        }
        scoreText.text = "souls taken: " + scoreCount;
//S         hiScoreText.text = "hi-score: " + hiScoreCount;
        
    }

    public static void azzeraScore()
    {
        scoreCount = 0;
    }
}
