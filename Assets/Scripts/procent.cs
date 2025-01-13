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

    void UpdatePiss()
    {
        Vector3 fwd = player.transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(player.transform.position, fwd, 10))
        {
            pee += Time.deltaTime * 10;
            counter.text = "Sanity: " + pee.ToString("F1") + "%";
        }

        if (chromaticAberration != null)
        {
            chromaticAberration.intensity.value = Mathf.Clamp(pee / 200f, 0, 1); 
        }

        if (pee >= 100f && pee <= 200f)
        {
            enemy.SetActive(false);
            peeanimation.SetActive(true);
            postpros.SetActive(true);
        }
        else if (pee > 200f)
        {
            peeanimation.SetActive(false);
            peeanimation2.SetActive(true);
        }
        else if (pee < 100f)
        {
            gameovertext.SetActive(false);
            peeanimation.SetActive(false);
        }
    }
}
