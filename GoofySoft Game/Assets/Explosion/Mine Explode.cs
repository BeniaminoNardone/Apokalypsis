using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplode : MonoBehaviour
{
    private GameObject bob; 
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player") {
            _animator.SetTrigger("isExploded");
        
  
        } 
        _animator.SetTrigger("idle");
    }
}
