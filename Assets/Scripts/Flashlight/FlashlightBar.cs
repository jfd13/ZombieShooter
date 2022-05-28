using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FlashlightBar : MonoBehaviour
{
    public FlashlightToggle flashLightToggle;
    public Slider slider;

    void Update()
    {
        slider.value = flashLightToggle.currentTime;
    }
}
