using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dart : MonoBehaviour
{
    public float speed= 200f;
    public Rigidbody dartRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        dartRigidbody.velocity = speed * transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        fetopiccolo enemy = hitInfo.GetComponent<fetopiccolo>();
        enemy.TakeDamage();
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
