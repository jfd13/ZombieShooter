using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotation_DIFFICULTY : MonoBehaviour
{
    public Transform panel;
    public Transform player;

    public void Update()
    {
        TurnToPlayer();
    }

    public void TurnToPlayer()
    {
        Vector3 lookPos = player.position - panel.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY - 180, 0);
        panel.transform.rotation = rotation;
    }
}
