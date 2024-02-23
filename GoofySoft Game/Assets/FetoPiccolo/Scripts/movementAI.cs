using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementAI : MonoBehaviour
{
    public GameObject player;
    public float speed;
     public Animator _animator;
    public int risultato;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _animator.SetFloat("angle", angle);

        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
 

        // Calcola la distanza lungo l'asse Z tra le due entità
        float distanzaZ = transform.position.z - player.transform.position.z;

        // Verifica se la seconda entità è più lontana o più vicina lungo l'asse Z
        if (distanzaZ > 0)
        {
            risultato = 1; // La seconda entità è più lontana
        }
        else if (distanzaZ < 0)
        {
            risultato = -1; // La seconda entità è più vicina
        }
        else
        {
            risultato = 0; // Le entità sono alla stessa distanza
        }
        _animator.SetFloat("Blend", risultato);


    }

}