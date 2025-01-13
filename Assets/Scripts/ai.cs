using System;
using System.Collections;
using System.Collections.Generic;
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

        if (player != null)
        {
            agent.SetDestination(player.position);
        }


       

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
