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
        if (hitInfo != null)
        {
            fetopiccolo enemy = hitInfo.GetComponent<fetopiccolo>();
            if (enemy != null)
            {
                enemy.TakeDamage();
                dartExplosion();

            }
            else
            {
                Debug.LogWarning("Il collider non ha il componente 'fetopiccolo'.");
            }
            Debug.Log(hitInfo.name);

        }
    }

    private void dartExplosion() {

        Destroy(gameObject);

    }

}
