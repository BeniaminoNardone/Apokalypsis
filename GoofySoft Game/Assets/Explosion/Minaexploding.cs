using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minaexploding : MonoBehaviour
{
    public Animator minaAnimator;
    // Start is called before the first frame update
   private void OnTrigger(Collider other) {
    
    if (other.CompareTag("Player")) {
        
        minaAnimator.SetTrigger("isExploded");

        GetComponent<Collider>().enabled = false;
        
        Debug.Log("esplodo");
    }

   }
}
