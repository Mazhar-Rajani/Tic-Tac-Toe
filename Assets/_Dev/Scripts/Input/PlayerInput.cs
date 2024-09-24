using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IGameplayInput
{
    public bool ProcessInput()
    {
        return Input.GetMouseButtonDown(0);
    }
}
