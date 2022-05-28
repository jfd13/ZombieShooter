using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryRandomSpawner : MonoBehaviour
{
    public GameObject battery;
    int xPosition;
    int zPosition;
    int batteryAmount;

    void Start()
    {
        StartCoroutine(BatterySpawn());
    }

    IEnumerator BatterySpawn()
    {
        while(batteryAmount < 10)
        {
            xPosition = Random.Range(18, 9);
            zPosition = Random.Range(-25, 10);
            Instantiate(battery, new Vector3(xPosition, -0.00235343f, zPosition), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            batteryAmount += 1;
        }
    }
}
