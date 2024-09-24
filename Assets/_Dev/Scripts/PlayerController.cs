using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class PlayerController : MonoBehaviour
{
    public static event Action OnTurnPlayed;

    [SerializeField] private int turnIndex = default;
    [SerializeField] private Board board = default;
    [SerializeField] private Shape crossPrefab = default;
    [SerializeField] private Shape circlePrefab = default;
    [SerializeField] private PreviewShape previewShape = default;

    private Cell currCell;
    private int currTurnIndex;
    private IGameplayInput input;

    private void Awake()
    {
        input = GetComponent<IGameplayInput>();
        previewShape.Init(turnIndex);

        TurnManager.OnTurnUpdated += OnTurnUpdated;
    }

    private void OnDestroy()
    {
        TurnManager.OnTurnUpdated -= OnTurnUpdated;
    }

    private void OnTurnUpdated(int turnIndex)
    {
        currTurnIndex = turnIndex;
    }

    private void Update()
    {
        if (!IsTurnValid() || !GetCurrCell())
            return;

        if (ProcessInput())
        {
            SpawnShape();
            OnTurnPlayed?.Invoke();
        }
    }

    private bool GetCurrCell()
    {
        if (board.GetCurrCell(Mouse.GetMouseWorldPos(), out Cell currCell))
        {

        }
    }

    private bool IsTurnValid()
    {
        return turnIndex == currTurnIndex;
    }

    private bool ProcessInput()
    {
        return input.ProcessInput();
    }



    private void SpawnShape()
    {
        Shape shape = Instantiate(turnIndex == 0 ? crossPrefab : circlePrefab, transform);
        shape.transform.position = currCell.cellPos;
    }



    private void OnDrawGizmos()
    {
        if (currCell == null)
            return;

        float hSize = currCell.cellSize * 0.5f;
        Draw.Rectangle(Vector3.zero, new Rect(currCell.cellPos.x - hSize, currCell.cellPos.y - hSize, currCell.cellSize, currCell.cellSize), new Color(1, 1, 1, 0.5f));
    }
}