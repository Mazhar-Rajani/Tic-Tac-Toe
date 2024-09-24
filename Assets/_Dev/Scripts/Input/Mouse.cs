using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mouse
{
    public static Vector3 GetMouseWorldPos()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0f;
        return worldPos;
    }
}
