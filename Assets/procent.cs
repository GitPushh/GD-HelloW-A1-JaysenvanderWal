using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class procent : MonoBehaviour
{
    // Start is called before the first frame update
    public Text counter;
    public GameObject gameovertext;
    public Text gameovertexttext;
    public GameObject player;
    public GameObject peeanimation;
    public GameObject peeanimation2;
    [SerializeField] GameObject enemy;
    public float pee;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePiss();

      

    }

    void UpdatePiss()
    {
        Vector3 fwd = player.transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(player.transform.position, fwd, 10))


            pee += Time.deltaTime * 10;
            counter.text = "Sanity: " + pee.ToString() + "%";





        if (pee >= 100f && pee <= 200f)
        {
            //gameovertext.SetActive(true);
            enemy.SetActive(false);
            peeanimation.SetActive(true);
        }
        else if (pee >= 200f)
        {
            //peeanimation.SetActive(false);
            //peeanimation2.SetActive(true);
        }
        else if (pee <= 100) 
        {
            //gameovertext.SetActive(false);
            //peeanimation.SetActive(false);

        }
    }

    
}
