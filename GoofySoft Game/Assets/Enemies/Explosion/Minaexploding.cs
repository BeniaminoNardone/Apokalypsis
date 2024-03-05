using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minaexploding : MonoBehaviour
{
    public Animator minaAnimator;
    // Start is called before the first frame update
   private void OnCollisionEnter(Collision collision){
    
    if (collision.gameObject.CompareTag("Player")) {
        
        minaAnimator.SetTrigger("isExploded");

        GetComponent<Collider>().enabled = false;
        
        Debug.Log("esplodo");
    }

   }
}
