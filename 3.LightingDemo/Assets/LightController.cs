using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] lights; 
    public Renderer[] lightBulbRenderers; 

    private bool lightsOn = true; 

    void Start()
    {
        foreach (var light in lights)
        {
            light.enabled = false;
        }


        if (lights == null || lights.Length == 0)
        {
            lights = GetComponentsInChildren<Light>();
        }

        if (lightBulbRenderers == null || lightBulbRenderers.Length == 0)
        {
            lightBulbRenderers = GetComponentsInChildren<Renderer>();
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleLights();
        }
    }

    void ToggleLights()
    {
        if (lightsOn)
        {
            lightsOn = false;
        }

        else
        {
            lightsOn = true;
        }

        foreach (var light in lights)
        {
            light.enabled = lightsOn;
        }

        foreach (var renderer in lightBulbRenderers)
        {
            foreach (var material in renderer.materials)
            {
                if (material.HasProperty("_IsLightOn"))
                {
                    material.SetFloat("_IsLightOn", lightsOn ? 2.0f : 0.0f);
                }
            }
        }
    }
}