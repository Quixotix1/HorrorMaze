using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamInput : MonoBehaviour
{
    /**
     * CREDIT https://www.youtube.com/watch?v=f473C43s8nE
     * "FIRST PERSON MOVEMENT in 10 MINUTES - Unity Tutorial" by Dave / GameDevelopment
     */

    public float sensX;
    public float sensY;

    public Transform orientation;

    float rotX;
    float rotY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float inX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float inY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        rotY += inX;
        rotX -= inY;
        rotX = Mathf.Clamp(rotX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        orientation.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
