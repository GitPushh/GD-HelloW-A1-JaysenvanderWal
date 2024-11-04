using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ai : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    private NavMeshAgent agent;
    public GameObject ui;
    public GameObject Player;




    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Find the player in the scene by tag if not manually assigned
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
        // Set the agent's destination to the player's position
        if (player != null)
        {
            agent.SetDestination(player.position);
            Debug.Log("working");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "player")
        {
            Destroy(Player);
            ui.SetActive(true);
            Debug.Log("working");
        }
    }
}
