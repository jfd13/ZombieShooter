using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashLight;
    private bool isFlashLightActive;

    void Start()
    {
        flashLight.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isFlashLightActive == false)
        {
            flashLight.enabled = true;
            isFlashLightActive = true;
        }
        else if(Input.GetKeyDown(KeyCode.F) && isFlashLightActive == true)
        {
            flashLight.enabled = false;
            isFlashLightActive = false;
        }
    }
}
