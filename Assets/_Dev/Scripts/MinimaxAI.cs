using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimaxAI : MonoBehaviour
{
    [SerializeField] private Board board = default;

    public Cell FindBestMove()
    {
        int bestScore = -int.MaxValue;
        Cell bestMove = null;

        foreach (Cell cell in board.Cells)
        {
            if (!cell.isOccupied)
            {
                int score = Minimax(cell, 0, false);
                if(score > bestScore)
                {
                    bestScore = score;
                    bestMove = cell;
                }
            }
        }
        return bestMove;
    }

    private int Minimax(Cell cell, int depth, bool isMaximizing)
    {
        return 1;
    }
}