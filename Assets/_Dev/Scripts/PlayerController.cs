using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class PlayerController : MonoBehaviour
{
    public static event Action OnTurnStart;

    [SerializeField] private int playerTurnIndex = default;
    [SerializeField] private Board board = default;
    [SerializeField] private Shape crossPrefab = default;
    [SerializeField] private Shape circlePrefab = default;
    [SerializeField] private TurnManager turnManager = default;

    private Cell currCell;
    private Shape currShape;

    private void Awake()
    {
        currShape = Instantiate(turnManager.turnIndex == 0 ? crossPrefab : circlePrefab, transform);
    }

    private void Update()
    {
        if (playerTurnIndex != turnManager.turnIndex || !board.IsInBounds(GetMousePos()))
            return;

        currCell = board.GetCurrCell(GetMousePos());

        if (Input.GetMouseButtonUp(0))
        {
            currShape = Instantiate(turnManager.turnIndex == 0 ? crossPrefab : circlePrefab, transform);
            currShape.transform.position = currCell.cellPos;
            EvaluateGameState();
        }
        else
        {
            currShape.transform.position = currCell.cellPos;
        }
    }

    private void EvaluateGameState()
    {
        OnTurnStart?.Invoke();
    }

    private Vector3 GetMousePos()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0f;
        return worldPos;
    }

    private void OnDrawGizmos()
    {
        if (currCell == null)
            return;

        float hSize = currCell.cellSize * 0.5f;
        Draw.Rectangle(Vector3.zero, new Rect(currCell.cellPos.x - hSize, currCell.cellPos.y - hSize, currCell.cellSize, currCell.cellSize), new Color(1, 1, 1, 0.5f));
    }
}