using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 20;
    [SerializeField] float negativespeed = -200;
    [SerializeField] float JumpSpeed = 200f;
    [SerializeField] GameObject deadui;

    public Vector3 movement;


    void Start()
    {
        deadui.SetActive(false);
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "enenmy")
        {
            Destroy(this.gameObject);

        }
    }


}
