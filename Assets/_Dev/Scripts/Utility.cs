using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector2 GetWorldCameraSize()
    {
        return new Vector2(Camera.main.orthographicSize * 2f * Camera.main.aspect, Camera.main.orthographicSize * 2f);
    }
}