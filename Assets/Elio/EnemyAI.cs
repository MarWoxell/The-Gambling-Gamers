using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Script by Elio
    public NavMeshAgent agent;
    public Transform player;
    private Transform enemyTransform;
    public EnemyHead head;
    public GameObject enemy;
    public GameObject projectilePrefab;
    public GameObject moneyPrefab;
    public PauseMenu pause;
    float distance;
    private bool hasAttacked;
    private bool noDoubles = true;
    // Start is called before the first frame update
    void Start()
    {
        enemyTransform = enemy.transform;
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
        Instantiate(projectilePrefab, enemyTransform.position, enemyTransform.rotation);
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
        transform.LookAt(player);
        distance = Vector3.Distance(player.position, enemy.transform.position);
        //print(distance);
        if(distance >= 8)
        {
            agent.isStopped = false;
            ChasePlayer();
        }
        else
        {
            agent.isStopped = true;
        }
        if(distance <= 20 && hasAttacked == false && pause.paused == false)
        {
            StartCoroutine(Attack());
        }
        if(hasAttacked == true && noDoubles == true && pause.paused == false)
        {
            //nextAttack = Time.deltaTime + cooldown;
            StartCoroutine(EnemyShootCooldown());
        }

        if (head.health <= 0)
        {
            Instantiate(moneyPrefab, enemyTransform.position, enemyTransform.rotation);
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
