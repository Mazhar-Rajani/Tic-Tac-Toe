using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameComplete;
    public static event Action OnTurnComplete;

    [SerializeField] private Board board = default;

    private void Awake()
    {
        PlayerController.OnTurnPlayed += OnTurnPlayed;
    }

    private void OnDestroy()
    {
        PlayerController.OnTurnPlayed -= OnTurnPlayed;
    }

    private void OnTurnPlayed()
    {
        EvaluateGameState();
    }

    private void EvaluateGameState()
    {
        if (CheckForWinner())
        {
            OnGameComplete?.Invoke();
        }
        else
        {
            OnTurnComplete?.Invoke();
        }
    }

    private bool CheckForWinner()
    {
        if (!board.HasEmptyCells())
        {
            return true;
        }
        return false;
    }
}
