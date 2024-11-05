using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int gamePoints = 0;
    public Text pointtext;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PointsUpdate(int points)
    {
        gamePoints += points;
        pointtext.text = gamePoints.ToString();
        Debug.Log("Points added " + points);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "pointblock")
        {
            PointsUpdate(5);
            Destroy(collision.collider.gameObject);
        }
    }
}
