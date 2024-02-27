using UnityEngine.SceneManagement;
using UnityEngine;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
       if(!PlayerPrefs.HasKey("firstTime") || PlayerPrefs.GetInt("firstTime")!= 69)
        {
            PlayerPrefs.SetInt("firstTime", 69);
            PlayerPrefs.Save();

        }
       else if(PlayerPrefs.GetInt("firstTime") == 69)
        {
            SceneManager.LoadScene(10);
        }
        
    }
}
