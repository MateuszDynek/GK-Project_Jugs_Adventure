using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerLightControll : MonoBehaviour
{
    public Light myLight;
    private const float speed = 0.005f;
    private float time = 0.0f;
    private float intensityMin = 0.0f;
    private float intensityMax = 50.0f;
    private bool change = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(time>1.0f)
        {
            time=0.0f;
            change = !change;
        }
        if(change)
        {
            myLight.intensity = Mathf.Lerp(intensityMin,intensityMax,time);
            time += speed;
        }
        else
        {
            myLight.intensity = Mathf.Lerp(intensityMax,intensityMin,time);
            time += speed;
        }
        
        
    }
}
