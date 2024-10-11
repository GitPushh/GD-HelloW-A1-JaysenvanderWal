using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class deletecube : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject floor;
    public GameObject player;
    public float rotationSpeed = 10f; // adjust to your desired speed
    public Vector3 rotationAxis = Vector3.up;
    public GameObject ui;
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
   void OnCollisionEnter(Collision collision){
         if(collision.collider.tag == "floor"){
            Destroy(gameObject);
         }
         if(collision.collider.tag == "player"){
            ui.SetActive(true);
            Destroy(player);
            
         }
    }
    
}
