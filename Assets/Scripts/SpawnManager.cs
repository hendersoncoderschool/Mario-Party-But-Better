using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    public int enemiesSpawned;
    public int wave;
    public List<int> waveSizes = new List<int>();
    public GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {
        enemiesSpawned = 0;
        wave = 0;
        for(int i = 0; i < waveSizes[0]; i++){
            Instantiate(enemies[i], new Vector3(Random.Range(-10f, 10f), 9, Random.Range(-10f, 10f)), Quaternion.identity);
          }
          enemiesSpawned += waveSizes[0];
    }
    public void SpawnWave(){
        wave++;
        if(Random.Range(1,5) == 1){
            Instantiate(powerUp, new Vector3(Random.Range(-10f, 10f), 3, Random.Range(-10f, 10f)), Quaternion.identity);
        }
        for(int i = enemiesSpawned; i < enemiesSpawned + waveSizes[wave]; i++){
            Instantiate(enemies[i], new Vector3(Random.Range(-10f, 10f), 5, Random.Range(-10f, 10f)), Quaternion.identity);
        }
        enemiesSpawned += waveSizes[wave];
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = FindObjectsOfType<EnemyMove>().Length;
        if(enemyCount == 0 && wave < 6){
           SpawnWave();
        }
    }
}
