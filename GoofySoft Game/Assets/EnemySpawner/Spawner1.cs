using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    [SerializeField]
    private GameObject Fetopiccolo;
    [SerializeField]
    public GameObject player;

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
        Vector3 playerPosition = player.transform.position;
        float scostamento = Random.Range(-1f, 1f);
        if (scostamento == 0)
        {
            scostamento += 1;
        }
        GameObject newEnemy = Instantiate(Fetopiccolo, new Vector3(playerPosition.x + 40 * scostamento, 2, playerPosition.z + 30 * scostamento), Quaternion.Euler(33f, 0f, 0f));
        enemiesSpawned++;
    }
}
