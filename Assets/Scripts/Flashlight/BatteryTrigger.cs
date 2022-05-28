using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTrigger : MonoBehaviour
{
    public FlashlightToggle FlashLightScript;

    void OnTriggerEnter(Collider other)
    {
        FlashLightScript.ResetTimer();
        gameObject.SetActive(false);
    }
}
