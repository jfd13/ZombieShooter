using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashLight;
    bool isFlashLightActive;

    public float currentTime = 0f;
    [HideInInspector] public float startingTime = 10f;

    void Start()
    {
        if(flashLight == null)
        {
            return;
        }

        flashLight.enabled = false;

        currentTime = startingTime;
    }

    void Update()
    {
        if(flashLight == null)
        {
            return;
        }

        // Turns on the flashlight
        if (Input.GetKeyDown(KeyCode.F) && isFlashLightActive == false)
        {
            flashLight.enabled = true;
            isFlashLightActive = true;
        }

        // Turns off the flashlight
        else if (Input.GetKeyDown(KeyCode.F) && isFlashLightActive == true)
        {
            flashLight.enabled = false;
            isFlashLightActive = false;
        }

        Timer();
    }

    public void Timer()
    {
        float intensityNumber = Mathf.PerlinNoise(Time.time,Time.time*Random.Range(0f, 1f));

        if (isFlashLightActive == true)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                flashLight.enabled = false;
                isFlashLightActive = false;
            }

            else if (currentTime <= 5f)
            {
                flashLight.intensity = intensityNumber;
            }
        }
    }

    public void ResetTimer()
    {
        currentTime = startingTime;
    }

    public void ResetIntensity()
    {
        flashLight.intensity = 3f;
    }
}