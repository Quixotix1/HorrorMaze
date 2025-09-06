using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLock : MonoBehaviour
{
    /**
     * CREDIT https://www.youtube.com/watch?v=f473C43s8nE
     * "FIRST PERSON MOVEMENT in 10 MINUTES - Unity Tutorial" by Dave / GameDevelopment
     */

    public Transform camLoc;

    void LateUpdate()
    {
        transform.position = camLoc.position;
    }
}
