using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class procent : MonoBehaviour
{
    public Text counter;
    public GameObject gameovertext;
    public Text gameovertexttext;
    public GameObject player;
    public GameObject peeanimation;
    public GameObject peeanimation2;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject postpros;
    float timer;

    public GameObject deathUI;



    public PostProcessVolume volume;
    public GameObject pp;
    public float pee;
    private ChromaticAberration chromaticAberration;

    void Start()
    {
        volume = pp.GetComponent<PostProcessVolume>();
        
    }

    void Update()
    {
        UpdatePiss();
        if (volume != null && volume.profile != null)
        {
            if (volume.profile.TryGetSettings(out chromaticAberration))
            {
                chromaticAberration.intensity.overrideState = true; 
                chromaticAberration.intensity.value = pee / 100; 
            }
            
        }
      
    }

    public void Death()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            deathUI.SetActive(true);
            Debug.Log("death");

        }
    }

    void UpdatePiss()
    {
        Vector3 fwd = player.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(player.transform.position, fwd, out hit, 30))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                pee += Time.deltaTime * 10;
            }
        }

        float displayValue = 100 - pee;

        displayValue = Mathf.Clamp(displayValue, 0, 100);

        counter.text = "Sanity: " + displayValue.ToString("F0") + "%";

        if (pee >= 100f && pee <= 200f)
        {
            enemy.SetActive(false);
            peeanimation.SetActive(true);
            Death();
        }
        else if (pee > 200f)
        {
            peeanimation.SetActive(false);
        }

    }
}
