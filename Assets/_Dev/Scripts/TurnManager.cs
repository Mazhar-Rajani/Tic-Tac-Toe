using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int turnIndex;

    private void Awake()
    {
        turnIndex = 0;
        PlayerController.OnTurnStart += OnTurnPlayed;
    }

    private void OnDestroy()
    {
        PlayerController.OnTurnStart -= OnTurnPlayed;
    }

    private void OnTurnPlayed()
    {
        turnIndex = turnIndex == 0 ? 1 : 0;
    }
}