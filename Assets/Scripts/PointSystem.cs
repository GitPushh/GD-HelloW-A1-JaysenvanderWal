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

    public procent procent;





    void Start()
    {
        pointtext.text = "Collected: " + gamePoints.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void PointsUpdate(int points)
    {
        gamePoints += points;
        pointtext.text = "Collected: " + gamePoints.ToString();
        Debug.Log("Points added " + points);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "pointblock")
        {
            PointsUpdate(1);
            Destroy(collision.collider.gameObject);

            Debug.Log("kaas");
        }

        if(collision.collider.tag == "sanity")
        {
            Destroy(collision.collider.gameObject);
            procent.pee = 1f;
            
        }
    }
}
