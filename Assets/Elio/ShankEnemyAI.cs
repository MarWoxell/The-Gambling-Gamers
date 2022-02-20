using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShankEnemyAI : MonoBehaviour
{
    //Script by Elio
    public NavMeshAgent agent;
    public Transform player;
    public EnemyHead head;
    public GameObject moneyPrefab, healthPrefab;
    public GameObject Blood;
    public PauseMenu pause;
    public hpsliderscript healthbar;
    public int drops;
    private bool hasAttacked;
    private bool noDoubles = true;
    IEnumerator EnemyShootCooldown()
    {
        //If the game is not paused the enemy will wait between 3-5 seconds until it can attack again
        if (pause.paused == false)
        {
            noDoubles = false;
        }
        //Waits for three seconds then makes it possible for the enemy to attack again
        yield return new WaitForSecondsRealtime(3);
        if (pause.paused == false)
        {
            hasAttacked = false;
            noDoubles = true;
        }
    }
    
    public void TakeDamage(int amount)
    {
        //Makes head take damage by a certain "amount"
        head.health -= amount;
    }


    // Update is called once per frame
    void Update()
    {
        //Changes the drops between two numbers every frame, makes it so that the enemy always looks at the player
        drops = Random.Range(0, 2);
        transform.LookAt(player);
        ChasePlayer();
        

        //Starts the enmy's cooldown if the listed conditions are met
        if (hasAttacked == true && noDoubles == true && pause.paused == false)
        {
            StartCoroutine(EnemyShootCooldown());
        }

        //If the player's head's health becomes zero
        if (head.health <= 0)
        {
            //Instantiates blood in enemy's position
            Instantiate(Blood, transform.position, transform.rotation);
            //50 / 50 chance to drop either a healing item or money if the enemy is not at full health but if player is at full health it always drops money
            if (drops == 0 && healthbar.playerhp < 100)
            {
                Instantiate(healthPrefab, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(moneyPrefab, transform.position, transform.rotation);
            }
            //Lowers the variablle for the amount of enemies alive and destroys the enemy
            SpawnEnemy.areThereEnemiesAlive--;
            Destroy(this.gameObject);
        }
    }
    private void ChasePlayer()
    {
        //Makes the enemy chase the player
        agent.SetDestination(player.position);
    }
}
