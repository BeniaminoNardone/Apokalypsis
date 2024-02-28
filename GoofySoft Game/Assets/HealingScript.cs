using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Button lifeButton;

    private int maxLives = 3; // Maximum number of lives
    private int currentLives = 3; // Current number of lives

    void Start()
    {
        lifeButton.onClick.AddListener(IncreaseLife);
    }

    void IncreaseLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            Debug.Log("Life increased to " + currentLives);
        }
        else
        {
            Debug.Log("Maximum lives already reached!");
        }
    }
}
