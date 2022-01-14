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
    public GameObject enemy;
    public GameObject projectilePrefab;
    float distance;
    private bool hasAttacked;
    private bool noDoubles = true;
    private float cooldown;
    private float nextAttack;
    // Start is called before the first frame update
    void Start()
    {
        enemyTransform = enemy.transform;
    }
    IEnumerator EnemyShootCooldown()
    {
        noDoubles = false;
        //Waits for some time
        yield return new WaitForSecondsRealtime(Random.Range(3f, 5f));
        hasAttacked = false;
        noDoubles = true;
    }
    IEnumerator Attack()
    {
        print("aofieajoief");
        Instantiate(projectilePrefab, enemyTransform.position, enemyTransform.rotation);
        hasAttacked = true;
        yield return new WaitForSecondsRealtime(5);
        //Destroy(attack);
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
        if(distance <= 20 && hasAttacked == false)
        {
            StartCoroutine(Attack());
            print("Poop");
        }
        if(hasAttacked == true && noDoubles == true)
        {
            print("Shit");
            //nextAttack = Time.deltaTime + cooldown;
            StartCoroutine(EnemyShootCooldown());
        }


    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

    }
    /**/
}
