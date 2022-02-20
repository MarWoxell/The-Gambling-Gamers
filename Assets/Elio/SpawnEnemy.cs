using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnEnemy : MonoBehaviour
{
    //Script by Elio
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoints;
    public Text wave;
    public int[] waveAmount;
    public int enemyType;
    public int i;
    public int z;
    public int spawnPosition;
    public int waveNumber;
    public static int areThereEnemiesAlive;
    // Start is called before the first frame update
    void Start()
    {
        areThereEnemiesAlive = 0;
        waveAmount[0] = 1;
        waveNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //If there are no enemies alive
        if (areThereEnemiesAlive == 0)
        {
            StartCoroutine(NextWave());
            //Makes it so that the next wave to come will have twice as many enemies as the last wave
            waveAmount[waveNumber] = waveAmount[waveNumber - 1] * 2;

            //Spawns the enemy according to the amount speciefied in waveAmount
            for (i = 0; i <= waveAmount[waveNumber]; i++)
            {
                //Resets the amount of enemies alive to the new amount of enemies coming
                if (i == 0)
                {
                    areThereEnemiesAlive = waveAmount[waveNumber];
                }
                //Spawns enemy after a cooldown
                else
                {
                    StartCoroutine(SpawnsEnemy());
                }


            }
            //Increses wavenumber value so that next wave will have more enemies and resets i's value
            waveNumber++;
            i = 0;
        }
    }

    public IEnumerator SpawnsEnemy()
    {
        //Waits for a second
        yield return new WaitForSecondsRealtime(3);
        //Spawns an enemy in one of eight different positions
        spawnPosition = Random.Range(0, 8);
        enemyType = Random.Range(0, 2);
        print(enemyType);
        Instantiate(enemyPrefab[enemyType], spawnPoints[spawnPosition].position, spawnPoints[spawnPosition].rotation);
    }
    public IEnumerator NextWave()
    {
        //Shows that the "Starting wave" text, waits for three seconds, then makes the text dissapear
        wave.text = "Starting wave " + waveNumber.ToString();
        yield return new WaitForSecondsRealtime(3);
        wave.text = null;
    }
}
