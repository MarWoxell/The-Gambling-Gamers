using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Script by Elio
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundMask, playerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AttackSphere")
        {
            agent.speed = 0;
        }
        else
        {
            print("What");  
            agent.speed = 10;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        

    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }
    /**/
}
