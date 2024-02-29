using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSpawner : MonoBehaviour
{
    public float countdownTime = 2f;
    [System.Serializable]

    public class WaveContent {
        [SerializeField][NonReorderable] GameObject[] monsterSpawner;

        public GameObject[] GetMonsterSpawnList() {
            return monsterSpawner;
        }
    }

    [SerializeField][NonReorderable] WaveContent[] waves;
    int currentWave = 0;
    float spawnRange = 10;
    public List<GameObject> currentMonster;
    bool isCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(currentMonster.Count == 0 && !isCooldown) {
            StartCoroutine(StartCooldown());
        }
        
    }
    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(countdownTime);
        isCooldown = false;
        currentWave++;
        SpawnWave();
    }

    void SpawnWave() {
        for(int i = 0; i < waves[currentWave].GetMonsterSpawnList().Length; i++) {
            
            GameObject newspawn = Instantiate(waves[currentWave].GetMonsterSpawnList()[i], FindSpawnLoc(),Quaternion.identity);
            currentMonster.Add(newspawn);

            fetopiccolo monster = newspawn.GetComponent<fetopiccolo>();
            monster.SetSpawner(this);

            
}
    }

    Vector3 FindSpawnLoc() {

        Vector3 SpawnPos; 

            float xLoc = Random.Range(-spawnRange, spawnRange) + transform.position.x;
            float zLoc = Random.Range(-spawnRange, spawnRange) + transform.position.z;
            float yLoc = transform.position.y;

            SpawnPos = new Vector3(xLoc, yLoc, zLoc);

            if (Physics.Raycast(SpawnPos, Vector3.down,5)) {

                return SpawnPos;
            } else {
                return FindSpawnLoc();
            }

    }
}
