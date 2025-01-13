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
    private float timer;
    public GameObject deathUI;


    public bool collided = false;

    public procent procent;




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

        if (collided == true) {
            timer += Time.deltaTime;
            deathUI.SetActive(true);
            Debug.Log("death");
        }

    }

    


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "player")
        {
            collided = true;

            monster.SetActive(true);
            this.gameObject.SetActive(false);


            
        }
    }
}
