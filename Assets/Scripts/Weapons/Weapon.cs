using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("General")]
    public Camera mainCamera;

    [Header("Ints")]
    public int startingAmmoAmount;
    public int damage;

    [Header("Floats")]
    public float tapFireRate;
    public float holdFireRate;
    public float spread;
    public float reloadingTime;
    public float bulletRange;
    private float lastShot;

    [Header("Bools")]
    public bool holdToShoot;
    public bool tapToShoot;
    bool canShoot;

    [Header("Info")]
    public int ammoAmount;
    public bool reloading;
    public bool reload;

    void Start()
    {
        canShoot = true;
        ammoAmount = startingAmmoAmount;
    }

    void Update()
    {
        // Holding guns
        if (Input.GetKey(KeyCode.Mouse0) && holdToShoot && canShoot && !reloading)
        {
            RaycastHit hit;

            if (Time.time < holdFireRate + lastShot) return;
            {
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, bulletRange))
                {
                    print(hit.collider.gameObject.name);
                }

                lastShot = Time.time;
            }

            ammoAmount = ammoAmount - 1;

            if (ammoAmount <= 0)
            {
                ammoAmount = 0;
                reload = true;
                canShoot = false;
            }

            if (ammoAmount < startingAmmoAmount)
            {
                reload = true;
            }
        }

        // Tap guns
        if (Input.GetKeyDown(KeyCode.Mouse0) && tapToShoot && canShoot && !reloading)
        {
            RaycastHit hit;

            if (Time.time < tapFireRate + lastShot) return;
            {
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, bulletRange))
                {
                    print(hit.collider.gameObject.name);
                }

                lastShot = Time.time;
            }

            ammoAmount = ammoAmount - 1;

            if (ammoAmount <= 0)
            {
                ammoAmount = 0;
                reload = true;
                canShoot = false;
            }

            if (ammoAmount < startingAmmoAmount)
            {
                reload = true;
            }
        }

        IEnumerator AfterReload()
        {
            yield return new WaitForSeconds(reloadingTime);
            reloading = false;
            reload = false;
            ammoAmount = startingAmmoAmount;
            canShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.R) && reload && !reloading)
        {
            reloading = true;
            StartCoroutine(AfterReload());
        }
    }
}