using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCursor : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject cursor;

    public void Update()
    {
        ShowCursor();
    }

    public void ShowCursor()
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
