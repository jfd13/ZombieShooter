using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    private int chosenWeapon = 0;

    void Start()
    {
        WeaponSelected();
    }

    void Update()
    {
        int previousWeaponSelected = chosenWeapon;

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            chosenWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            chosenWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            chosenWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            chosenWeapon = 3;
        }

        if(previousWeaponSelected != chosenWeapon)
        {
            WeaponSelected();
        }
    }

    public void WeaponSelected()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == chosenWeapon)
            {
                weapon.gameObject.SetActive(true);
            }

            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
