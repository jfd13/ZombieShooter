using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFire : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] float xOffset = 4f;
    [SerializeField] float yOffset = 4f;
    [SerializeField] int startPosition = 1;
    [SerializeField] int speed = 5;
    [SerializeField] int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        if(center == null) return;
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        position.x = center.position.x + xOffset*Mathf.Cos(startPosition*Mathf.PI+direction*Time.time*speed);
        position.z = center.position.z + yOffset*Mathf.Sin(startPosition*Mathf.PI+direction*Time.time*speed);
        transform.SetPositionAndRotation(position,rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if(center == null) return;
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        position.x = center.position.x + xOffset*Mathf.Cos(startPosition*Mathf.PI+direction*Time.time*speed);
        position.z = center.position.z + yOffset*Mathf.Sin(startPosition*Mathf.PI+direction*Time.time*speed);
        transform.SetPositionAndRotation(position,rotation);
    }
}
