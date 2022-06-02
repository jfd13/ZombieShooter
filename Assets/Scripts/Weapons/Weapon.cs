using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Have to be changed, depends on the gun (Only in unity)
    [Header("General")]
    public Camera mainCamera;
    public GameObject reloadingText;
    public TextMeshProUGUI ammoText;

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

    // No changing values/bools
    [Header("Info")]
    public int ammoAmount;
    public bool reloading;
    public bool reload;

    void Start()
    {
        // Makes so that you could shoot
        canShoot = true;
        // Assigns the set ammo amount
        ammoAmount = startingAmmoAmount;
        // Sets the reloading text to false
        reloadingText.SetActive(false);
    }

    void Update()
    {
        // Holding guns
        if (Input.GetKey(KeyCode.Mouse0) && holdToShoot && canShoot && !reloading)
        {
            RaycastHit hit;

            // Firing rate
            if (Time.time < holdFireRate + lastShot) return;
            {

                Vector3 forward = mainCamera.transform.forward;

                // Bullet spread
                forward = forward + mainCamera.transform.TransformDirection(new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread)));

                // Shooting
                if (Physics.Raycast(mainCamera.transform.position, forward, out hit, bulletRange))
                {
                    // prints out the shot object's name
                    print(hit.collider.gameObject.name);
                }

                lastShot = Time.time;
            }

            // Every time you shoot, it subtracts ammo amount
            ammoAmount = ammoAmount - 1;

            // Keeps the ammo on 0 & disables shooting
            if (ammoAmount <= 0)
            {
                ammoAmount = 0;
                reload = true;
                canShoot = false;
            }

            // Tells when you can reload if less then the starting ammo amount
            if (ammoAmount < startingAmmoAmount)
            {
                reload = true;
            }
        }

        // Tap guns
        if (Input.GetKeyDown(KeyCode.Mouse0) && tapToShoot && canShoot && !reloading)
        {
            RaycastHit hit;

            // Firing rate
            if (Time.time < tapFireRate + lastShot) return;
            {
                Vector3 forward = mainCamera.transform.forward;

                // Bullet spread
                forward = forward + mainCamera.transform.TransformDirection(new Vector3(Random.Range(-spread, spread),Random.Range(-spread, spread)));

                // Shooting
                if (Physics.Raycast(mainCamera.transform.position, forward, out hit, bulletRange))
                {
                    // prints out the shot object's name
                    print(hit.collider.gameObject.name);
                }

                lastShot = Time.time;
            }

            // Every time you shoot, it subtracts ammo amount
            ammoAmount = ammoAmount - 1;

            // Keeps the ammo on 0 & disables shooting
            if (ammoAmount <= 0)
            {
                ammoAmount = 0;
                reload = true;
                canShoot = false;
            }

            // Tells when you can reload if less then the starting ammo amount
            if (ammoAmount < startingAmmoAmount)
            {
                reload = true;
            }
        }

        // Reload timer & after reload
        IEnumerator AfterReload()
        {
            yield return new WaitForSeconds(reloadingTime);
            reloading = false;
            reload = false;
            ammoAmount = startingAmmoAmount;
            canShoot = true;
        }

        // Reloading
        if (Input.GetKeyDown(KeyCode.R) && reload && !reloading)
        {
            reloading = true;
            StartCoroutine(AfterReload());
        }

        // Enables the reloading text when you reload
        if(reloading)
        {
            reloadingText.SetActive(true);
        }
        // Disables if not reloading
        else
        {
            reloadingText.SetActive(false);
        }

        // Ammo amount text
        ammoText.SetText($"{ammoAmount} / {startingAmmoAmount}");
    }
}