using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.AI;

public class procent : MonoBehaviour
{
    public Text counter;
    public GameObject player;
    public GameObject jumpscare1;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject postpros;
    [SerializeField] float timer;
    [SerializeField] Text flashlightText;
    [SerializeField] GameObject flashlightlight;
    public float sanity;
    public NavMeshAgent agent;

    public GameObject deathUI;

    public float flashlightBattery = 100f;
    public Slider scrollbar;
    



    public PostProcessVolume volume;
    public GameObject pp;
    private ChromaticAberration chromaticAberration;
    private Grain grain;
    private Vignette vig;

    void Start()
    {
        volume = pp.GetComponent<PostProcessVolume>();
        
    }

    void Update()
    {

        UpdatePiss();
        FlashLightBatt();
        if (volume != null && volume.profile != null)
        {
            if (volume.profile.TryGetSettings(out chromaticAberration))
            {
                chromaticAberration.intensity.overrideState = true; 
                chromaticAberration.intensity.value = sanity / 100;
                
            }

            if(volume.profile.TryGetSettings(out grain))
            {
                grain.intensity.overrideState = true;
                grain.intensity.value = sanity / 100;

            }
            if(volume.profile.TryGetSettings(out vig))
            {
                vig.intensity.overrideState = true;
                vig.intensity.value = sanity / 200;
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
                sanity += Time.deltaTime * 10;
            }
        }


        float displayValue = 100 - sanity;

        displayValue = Mathf.Clamp(displayValue, 0, 100);

        counter.text = "Sanity: " + displayValue.ToString("F0") + "%";

        if (sanity >= 100f && sanity <= 200f)
        {
            enemy.SetActive(false);
            jumpscare1.SetActive(true);
            Death();
        }

        if(sanity < 20)
        {
            agent.speed = 3.5f;
        }
        else
        {
            agent.speed = sanity / 10;
        }


    }

    void FlashLightBatt()
    {
        flashlightBattery -= Time.deltaTime * 2;
        scrollbar.value = flashlightBattery / 100;


        if (flashlightBattery <= 0)
        flashlightlight.SetActive(false);
    }
}
