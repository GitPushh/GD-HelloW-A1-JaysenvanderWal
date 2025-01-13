using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] procent procent;
    bool collided = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            procent.Death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            collided = true;
        }
    }
}
