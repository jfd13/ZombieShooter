using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashLight;
    bool isFlashLightActive;
    bool isFlashLightActiveBefore;

    public float currentTime = 0f;
    private float startingTime = 5f;

    void Start()
    {
        flashLight.enabled = false;

        currentTime = startingTime;
    }

    void Update()
    {
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
        if (isFlashLightActive == true)
        {
            currentTime -= Time.deltaTime;
            print(currentTime);

            if (currentTime <= 0)
            {
                flashLight.enabled = false;
                isFlashLightActive = false;
            }
        }
    }

    public void ResetTimer()
    {
        currentTime = startingTime;
    }
}