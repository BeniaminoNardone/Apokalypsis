using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class FollowTerrainRotation : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        // Trova il transform del player
        playerTransform = transform.parent;
    }

    void LateUpdate()
    {
        // Ottieni la normale del terreno sotto al player
        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            // Ruota il punto in modo che la sua up vector sia parallela alla normale del terreno
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
    }
}
