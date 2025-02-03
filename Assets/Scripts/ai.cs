using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class ai : MonoBehaviour
{
    public Transform player;  
    private NavMeshAgent agent;
    public GameObject ui;
    public GameObject Player;
    public GameObject monster;
    public GameObject raycast;
    public GameObject spawn;

    public float wanderRadius = 40f; 
    public float wanderInterval = 0.3f;
    public float timewanderedmax;
    private float wanderTimer;







    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("player");
            if (playerObject != null)
            {
                player = playerObject.transform;
                
            }
        }
    }

    void Update()
    {
        Vector3 directionToPlayer = (player.position - raycast.transform.position).normalized;
        RaycastHit hit;

        if (Physics.Raycast(raycast.transform.position, directionToPlayer, out hit, 30))
        {
            if (hit.collider.CompareTag("player"))
            {
                if (player != null)
                {
                    agent.SetDestination(player.position);
                    timewanderedmax = 0f;

                }
               
                return;
            }
        }
       


        wanderTimer += Time.deltaTime;
        if (wanderTimer >= wanderInterval)
        {
            Vector3 newWanderPosition = GetRandomWanderPosition();
            agent.SetDestination(newWanderPosition);
            wanderTimer = 0f;

         
        }

        timewanderedmax += Time.deltaTime;

        if (timewanderedmax >= 15f)
        {
            transform.position = spawn.transform.position;
        }




    }

    Vector3 GetRandomWanderPosition()
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, wanderRadius, NavMesh.AllAreas);

        return navHit.position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "player")
        {
            agent.enabled = false;
            monster.SetActive(true);
            this.gameObject.SetActive(false);


            
        }
    }
}
