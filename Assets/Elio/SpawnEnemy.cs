using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int[] waveAmount;
    public int i;
    public int waveNumber = 0;
    public static int areThereEnemiesAlive;
    // Start is called before the first frame update
    void Start()
    {
        areThereEnemiesAlive = waveAmount[waveNumber];
    }
    IEnumerator EnemySpawnCooldown()
    {
        yield return new WaitForSecondsRealtime(5f);
    }

    // Update is called once per frame
    void Update()
    {
        print(i);
        //Spawns the enemy according to the amount speciefied in waveAmount with a half second interval
        for(i = 0; i < waveAmount[waveNumber]; i++)
        {
            if(i == 0)
            {
                areThereEnemiesAlive = waveAmount[waveNumber];
            }
            SpawnsEnemy();
            
        }
        if (waveAmount[waveNumber] == i && areThereEnemiesAlive == 0)
        {
            waveNumber++;
            i = 0;
            print("yupyup");
        }
    }

    public void SpawnsEnemy()
    {
        EnemySpawnCooldown();
        Instantiate(enemyPrefab);
    }
}
