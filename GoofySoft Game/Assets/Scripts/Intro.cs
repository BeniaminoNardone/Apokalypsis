using UnityEngine.SceneManagement;
using UnityEngine;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
       if(!PlayerPrefs.HasKey("firstTime") || PlayerPrefs.GetInt("firstTime")!= 71)
        {
            PlayerPrefs.SetInt("firstTime", 71);
            PlayerPrefs.Save();

        }
       else if(PlayerPrefs.GetInt("firstTime") == 71)
        {
            SceneManager.LoadScene(10);
        }
        
    }
}
