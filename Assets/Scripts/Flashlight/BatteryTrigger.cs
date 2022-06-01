using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTrigger : MonoBehaviour
{
    public FlashlightToggle FlashLightScript;

    void OnTriggerEnter(Collider other)
    {
        if(FlashLightScript != null){
            if(FlashLightScript.currentTime == FlashLightScript.startingTime)
            {
            }
            else
            {
                FlashLightScript.ResetTimer();
                FlashLightScript.ResetIntensity();
                gameObject.SetActive(false);
            }
        }
    }
}
