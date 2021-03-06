using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    Transform transformComponent;
    Light lightComponent;
    [SerializeField]
    float minIntensity = 16;
    [SerializeField]
    float maxIntensity = 50;
    float nextLightning = 0;
    [SerializeField]
    float lightningDuration = 1;
    float endOfLightning = 0;
    // Start is called before the first frame update
    void Start()
    {
        transformComponent = GetComponent<Transform>();
        lightComponent = GetComponent<Light>();
        nextLightning = Time.time + 3;
        endOfLightning = nextLightning + lightningDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextLightning){
            lightComponent.intensity = minIntensity + maxIntensity * Mathf.PerlinNoise(Time.time*10,0);
            if(Time.time > endOfLightning){
                nextLightning = Time.time + Random.Range(1,6);
                endOfLightning = nextLightning + lightningDuration;
                Vector3 lightPosition = transformComponent.position;
                lightPosition.x = Random.Range(20,-30);
                lightPosition.z = Random.Range(6,-40);
                Quaternion lightRotation = transformComponent.rotation;
                transformComponent.SetPositionAndRotation(lightPosition,lightRotation);
            }
        }
        else{
            lightComponent.intensity = 0;
        } 
    }
}
