using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    float waittime = 1f;
    public float currentTime = 0f;
    public GameObject cube;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int random = UnityEngine.Random.Range(0, 3);
        currentTime += Time.deltaTime;
       if(currentTime > waittime){
            Instantiate(cube, transform.position, Quaternion.identity);
            currentTime = 0;
            if (random == 0)
            {
                transform.position += new Vector3(5, 0, 0);
                
            }
            else if (random == 1) {
                transform.position += new Vector3(-5, 0, 0);

            }
            else if (random == 2)
            {
                transform.position = new Vector3(0, 10, 0);
            }

        }
    }
}
