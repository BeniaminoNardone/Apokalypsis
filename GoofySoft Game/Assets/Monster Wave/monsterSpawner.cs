using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterSpawner : MonoBehaviour
{
    public Text waveNumberText;
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
    float spawnRange = 60;
    public List<GameObject> currentMonster;
    bool isCooldown = false;
    public ParticleSystem spawnEffect; // Aggiungi qui il riferimento all'effetto particellare
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
        UpdateWaveNumberText();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(currentMonster.Count == 0 && !isCooldown && currentWave<waves.Length) {//qui va messa come condizione anche il numero di currentwave < wave impostate-1  altrimenti va out of index
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
        UpdateWaveNumberText();
    }

    /* void SpawnWave() {
         for(int i = 0; i < waves[currentWave].GetMonsterSpawnList().Length; i++) {
             Vector3 SpawnPos= FindSpawnLoc();


              // Attiva l'effetto particellare al momento dello spawn
             Instantiate(spawnEffect, SpawnPos, Quaternion.identity);
             GameObject newspawn = Instantiate(waves[currentWave].GetMonsterSpawnList()[i], SpawnPos, Quaternion.Euler(33f, 0f, 0f));
             currentMonster.Add(newspawn);

             fetopiccolo monster = newspawn.GetComponent<fetopiccolo>();
             monster.SetSpawner(this);


         }
     }*/
    //questo è piu bello da vedere ma istanzia 2 waves alla volta

  void UpdateWaveNumberText()
    {
        if (waveNumberText != null) // Assicurati che il riferimento al UI Text sia valido
        {
            waveNumberText.text = "Wave: " + (currentWave); // Aggiorna il testo con il numero corrente della wave
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < waves[currentWave].GetMonsterSpawnList().Length; i++)
        {
            Vector3 SpawnPos = FindSpawnLoc();

            // Attiva l'effetto particellare
            Instantiate(spawnEffect, SpawnPos, Quaternion.identity);

            // Invoca l'istanza del mostro dopo un ritardo di 2 secondi
            StartCoroutine(SpawnMonsterWithDelay(SpawnPos, i, 2f));
        }
    }

    IEnumerator SpawnMonsterWithDelay(Vector3 SpawnPos, int index, float delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject newspawn = Instantiate(waves[currentWave].GetMonsterSpawnList()[index], SpawnPos, Quaternion.Euler(33f, 0f, 0f));
        currentMonster.Add(newspawn);

        fetopiccolo monster = newspawn.GetComponent<fetopiccolo>();
 
        monster.SetSpawner(this);
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
