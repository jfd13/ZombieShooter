using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("General")]
    public Camera mainCamera;

    [Header("Ints")]
    public int ammoAmount;
    public int damage;

    [Header("Floats")]
    public float fireRate;
    public float spread;
    public float bulletRange;

    [Header("Bools")]
    public bool holdToShoot;
    public bool tapToShoot;
    bool readyToShot;

    void Start()
    {
        
    }

    void Update()
    {
        // Holding guns
        if(Input.GetKey(KeyCode.Mouse0) && holdToShoot)
        {
            RaycastHit hit;

            if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, bulletRange))
            {
                print(hit.collider.gameObject.name);
            }
        }

        // Tap guns
        if (Input.GetKeyDown(KeyCode.Mouse0) && tapToShoot)
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, bulletRange))
            {
                print(hit.collider.gameObject.name);
            }
        }
    }
}
