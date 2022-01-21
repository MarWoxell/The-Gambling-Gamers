using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnEnemy : MonoBehaviour
{
    //Script by Elio
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public Text wave;
    public int[] waveAmount;
    public int i;
    public int z;
    public int spawnPosition;
    public int waveNumber = 0;
    public static int areThereEnemiesAlive = 0;
    // Start is called before the first frame update
    void Start()
    {
        waveAmount[0] = 1;
        waveNumber++;
    }

    IEnumerator EnemySpawnCooldown()
    {
        //Waits for some time
        yield return new WaitForSecondsRealtime(1);
    }

    // Update is called once per frame
    void Update()
    {
        //If there are no enemies alive
        if (areThereEnemiesAlive == 0)
        {
            StartCoroutine(NextWave());
            waveAmount[waveNumber] = waveAmount[waveNumber - 1] * 2;

            //Spawns the enemy according to the amount speciefied in waveAmount
            for (i = 0; i <= waveAmount[waveNumber]; i++)
            {
                //Resets the amount of enemies allive to the new amount of enemies coming
                if (i == 0)
                {
                    areThereEnemiesAlive = waveAmount[waveNumber];
                }
                //Spawns enemy after a cooldown
                else
                {
                    StartCoroutine(EnemySpawnCooldown());
                    SpawnsEnemy();
                }


            }
            //Increses wavenumber value so that next wave will have more enemies and resets i's value
            waveNumber++;
            i = 0;
        }
    }

    public void SpawnsEnemy()
    {

        spawnPosition = Random.Range(0, 8);
        //Spawns enemy
        Instantiate(enemyPrefab, spawnPoints[spawnPosition].position, spawnPoints[spawnPosition].rotation);
    }
    public IEnumerator NextWave()
    {
        wave.text = "Starting wave " + waveNumber.ToString();
        yield return new WaitForSecondsRealtime(3);
        wave.text = null;
    }
}
