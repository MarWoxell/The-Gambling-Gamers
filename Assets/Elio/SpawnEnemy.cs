using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int[] waveAmount;
    public int i;
    public int waveNumber = 0;
    public static int areThereEnemiesAlive = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator EnemySpawnCooldown()
    {
        //Waits for some time
        yield return new WaitForSecondsRealtime(5f);
    }

    // Update is called once per frame
    void Update()
    {

        
        //If there are no enemies alive
        if (areThereEnemiesAlive == 0)
        {      
            //Spawns the enemy according to the amount speciefied in waveAmount
            for (i = 0; i < waveAmount[waveNumber]; i++)
            {
                //Resets the amount of enemies allive to the new amount of enemies coming
                if (i == 0)
                {
                    areThereEnemiesAlive = waveAmount[waveNumber];
                }
                //Spawns enemy after a cooldown
                else
                {
                    EnemySpawnCooldown();
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
        //Spawns enemy
        Instantiate(enemyPrefab);
    }
}
