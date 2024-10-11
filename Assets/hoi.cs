using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 20;
    [SerializeField] float negativespeed = -200;
    public Vector3 movement;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

       
    }
    void FixedUpdate()
    {
        moveCharacter(movement);
    }


    void moveCharacter(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }
}
