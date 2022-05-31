using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTrigger : MonoBehaviour
{
    public FlashlightToggle FlashLightScript;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Battery triggered");
        if(FlashLightScript != null){
            FlashLightScript.ResetTimer();
            gameObject.SetActive(false);
        }
    }
}
