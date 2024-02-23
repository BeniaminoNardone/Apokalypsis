using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    [SerializeField]
    private GameObject Fetopiccolo;

    [SerializeField]
    private float fetopiccoloInterval = 3.5f;

    private int enemiesSpawned = 0;
    private const int maxEnemies = 15;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWithLimit(fetopiccoloInterval));
    }

    private IEnumerator SpawnEnemyWithLimit(float interval)
    {
        while (enemiesSpawned < maxEnemies)
        {
            yield return new WaitForSeconds(interval);
            InstantiateFetopiccolo();
        }
    }

    private void InstantiateFetopiccolo()
    {
        GameObject newEnemy = Instantiate(Fetopiccolo, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
        enemiesSpawned++;
    }
}
