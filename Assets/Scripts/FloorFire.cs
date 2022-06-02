using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFire : MonoBehaviour
{
    [SerializeField]
    Transform center;
    // Start is called before the first frame update
    void Start()
    {
        if(center == null) return;

    }

    // Update is called once per frame
    void Update()
    {
        if(center == null) return;
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        position.x = center.position.x + 4*Mathf.Sin(Time.time+Random.Range(1,10)*10);
        position.z = center.position.z + 4*Mathf.Cos(Time.time+Random.Range(1,10)*10);
        transform.SetPositionAndRotation(position,rotation);

    }
}
