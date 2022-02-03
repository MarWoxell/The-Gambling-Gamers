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
    public PauseMenu pause;
    public hpsliderscript healthbar;
    public int drops;
    float distance;
    private bool hasAttacked;
    private bool noDoubles = true;
    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator EnemyShootCooldown()
    {
        if(pause.paused == false)
        {
        noDoubles = false;
        }
        //Waits for some time
        yield return new WaitForSecondsRealtime(Random.Range(3f, 5f));
        if(pause.paused == false)
        {
        hasAttacked = false;
        noDoubles = true;
        }
    }
    IEnumerator Attack()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        hasAttacked = true;
        yield return new WaitForSecondsRealtime(5);
        //Destroy(attack);
    }
    public void TakeDamage(int amount)
    {
        head.health -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        drops = Random.Range(0, 2);
        transform.LookAt(player);
        distance = Vector3.Distance(player.position, enemy.transform.position);
        //print(distance);
        if(distance >= 50)
        {
            enemyAnimation.SetBool("If close", false);
            agent.isStopped = false;
            ChasePlayer();
        }
        else
        {
            enemyAnimation.SetBool("If close", true);
            Vector3 toPlayer = player.transform.position - transform.position;
            if (Vector3.Distance(player.transform.position, transform.position) < 3)
            {
                Vector3 targetPosition = toPlayer.normalized * -3f;
                agent.destination = targetPosition;
            }
            agent.isStopped = true;
            if(hasAttacked == false && pause.paused == false)
            {
            StartCoroutine(Attack());
            }
        }

        
        if(hasAttacked == true && noDoubles == true && pause.paused == false)
        {
            //nextAttack = Time.deltaTime + cooldown;
            StartCoroutine(EnemyShootCooldown());
        }

        if (head.health <= 0)
        {
            if(drops == 0 && healthbar.playerhp < 100)
            {
                Instantiate(healthPrefab, transform.position, transform.rotation);
            }
            else
            {
            Instantiate(moneyPrefab, transform.position, transform.rotation);
            }
            SpawnEnemy.areThereEnemiesAlive--;
            Destroy(this.gameObject);
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

    }
    /**/
}
