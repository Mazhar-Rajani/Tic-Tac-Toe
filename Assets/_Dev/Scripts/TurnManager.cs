using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static event Action<int> OnTurnUpdated;

    private int turnIndex;

    private void Awake()
    {
        turnIndex = 0;
        GameManager.OnTurnComplete += OnTurnComplete;
    }

    private void OnDestroy()
    {
        GameManager.OnTurnComplete -= OnTurnComplete;
    }

    private void OnTurnComplete()
    {
        turnIndex = turnIndex == 0 ? 1 : 0;
        OnTurnUpdated?.Invoke(turnIndex);
    }
}