using UnityEngine.SceneManagement;
using UnityEngine;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
       if(!PlayerPrefs.HasKey("firstTime") || PlayerPrefs.GetInt("firstTime")!= 70)
        {
            PlayerPrefs.SetInt("firstTime", 70);
            PlayerPrefs.Save();

        }
       else if(PlayerPrefs.GetInt("firstTime") == 70)
        {
            SceneManager.LoadScene(10);
        }
        
    }
}
