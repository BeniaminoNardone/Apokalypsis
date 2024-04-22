using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementAI : MonoBehaviour
{
    private GameObject player;
    public int speed;
    public Animator _animator;
    public int risultato;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        speed = Random.Range(5, 18);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _animator.SetFloat("angle", angle);

        Vector3 newPosition = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        newPosition.y = Mathf.Min(newPosition.y, this.transform.position.y); // Limita l'ascesa sull'asse y
        transform.position = newPosition;

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
