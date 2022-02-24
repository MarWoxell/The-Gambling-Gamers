using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Script by Elio
    public Animator enemyAnimation;
    public NavMeshAgent agent;
    public Transform player;
    public EnemyHead head;
    public GameObject enemy, projectilePrefab, moneyPrefab, healthPrefab;
    public GameObject Blood;
    public PauseMenu pause;
    public hpsliderscript healthbar;
    public AudioSource playerAudio;
    public AudioClip deathOuch;

    public int drops;
    float distance;
    private bool hasAttacked;
    private bool noDoubles = true;
    IEnumerator EnemyShootCooldown()
    {
        //If the game is not paused the enemy will wait between 3-5 seconds until it can attack again
        if(pause.paused == false)
        {
        noDoubles = false;
        }
        //Waits for some time
        yield return new WaitForSecondsRealtime(Random.Range(3f, 5f));
        hasAttacked = false;
        noDoubles = true;
    }
    public void Attack()
    {
        //Spawns attack in the enemy's position, making it look like the enemy is shoting a projectile, then makes hasAttacked true
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        hasAttacked = true;
        //Destroy(attack);
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
        //Makes the distance between the player a float variable
        distance = Vector3.Distance(player.position, enemy.transform.position);
        //If there is a 50 Unity Unit distance between the player and the enemy then the enemy starts it's walking animation and chases the player
        if(distance >= 50)
        {
            enemyAnimation.SetBool("If close", false);
            agent.isStopped = false;
            agent.speed = 10;
            ChasePlayer();
        }
        else
        {
            //If there isn't a 50 Unity Unit distance between the player and the enemy then the enemy stands still and stops it's animation
            enemyAnimation.SetBool("If close", true);
           
            if (Vector3.Distance(player.transform.position, transform.position) < 7)
            {
                //Makes the enemy quickly back away if you get too close 
                Vector3 toPlayer = player.transform.position - transform.position;
                Vector3 targetPosition = transform.position + toPlayer.normalized * -50f;
                agent.isStopped = false;
                agent.speed = 100;
                agent.SetDestination(targetPosition);
            }
            if (distance >= 7 && distance <= 50)
            {
                //Will stand still if you're not to close, nor too far away
                agent.isStopped = true;
            }
            //Attacks the player if the game isn't paused and hasn't attacked
            if (hasAttacked == false && pause.paused == false)
            {
                Attack();
            }
        }

        //Starts the enmy's cooldown if the listed conditions are met
        if(hasAttacked == true && noDoubles == true && pause.paused == false)
        {
            //nextAttack = Time.deltaTime + cooldown;
            StartCoroutine(EnemyShootCooldown());
        }

        //If the player's head's health becomes zero
        if (head.health <= 0)
        {
            //Instantiates blood in enemy's position and plays death sound (That happens to be really quiet)
            Instantiate(Blood, transform.position, transform.rotation);
            playerAudio.PlayOneShot(deathOuch, 10f);
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
