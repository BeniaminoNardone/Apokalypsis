using UnityEngine;

public class ControlManager : MonoBehaviour
{
    // Riferimento al componente dei controlli a schermo per telefono
    public GameObject mobileControls;

    void Start()
    {
        // Verifica se la piattaforma corrente è PC
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            // Disabilita i controlli a schermo per telefono
            mobileControls.SetActive(false);
        }
    }
}
