using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flashlightlight;
    public bool IsEnabled = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsEnabled == false) { 
            flashlightlight.SetActive(true);
            IsEnabled = true;
        }  else if (Input.GetKeyDown(KeyCode.F) && IsEnabled == true)
        {
            flashlightlight.SetActive(false);
            IsEnabled = false;

        }
    }
}
