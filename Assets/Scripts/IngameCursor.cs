using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCursor : MonoBehaviour
{

    public void Update()
    {
        UnlockCursor();
    }

    public void UnlockCursor()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
