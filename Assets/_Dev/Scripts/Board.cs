using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using System;

public class Board : MonoBehaviour
{
    [SerializeField] private Line linePrefab = default;
    [SerializeField] private Cell cellPrefab = default;
    [SerializeField] private int rowCount = default;
    [Range(0, 1)] [SerializeField] private float padding = default;

    private Vector2 size;
    private Vector3 origin;
    private float cellSize;
    private float halfSize;
    private float startPos;
    public List<Cell> Cells { get; private set; }

    private void Awake()
    {
        size = Utility.GetWorldCameraSize();
        cellSize = size.x / (float)rowCount;
        halfSize = size.x * 0.5f * padding;
        startPos = (-size.x * 0.5f) + cellSize;

        CreateCells();
        CreateLines();
    }

    private void CreateCells()
    {
        Cells = new List<Cell>();
        float x = -size.x * 0.5f + cellSize * 0.5f;
        float y = -size.x * 0.5f + cellSize * 0.5f;
        origin = new Vector3(x, y, 0);
        for (int c = 0; c < rowCount; c++)
        {
            for (int r = 0; r < rowCount; r++)
            {
                Cell cell = Instantiate(cellPrefab, transform);
                int index = c * rowCount + r;
                cell.Setup(index, origin, cellSize * padding);
                Cells.Add(cell);
                origin.x += cellSize;
            }
            origin.x = x;
            origin.y += cellSize;
        }
    }

    private void CreateLines()
    {
        for (int r = 0; r < rowCount - 1; r++)
        {
            Line hLine = Instantiate(linePrefab, transform);
            Line vLine = Instantiate(linePrefab, transform);

            float start = -halfSize;
            float end = halfSize;
            float pos = startPos + cellSize * r;

            hLine.Start = new Vector3(start, pos, 0f);
            hLine.End = new Vector3(end, pos, 0f);

            vLine.Start = new Vector3(pos, start, 0f);
            vLine.End = new Vector3(pos, end, 0f);
        }
    }

    public Cell GetCurrCell(Vector3 mousePos)
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hitInfo.collider != null && hitInfo.collider.TryGetComponent(out Cell cell))
        {
            return cell;
        }
        return null;
    }

    public bool IsInBounds(Vector3 mousePos)
    {
        float x = mousePos.x;
        float y = mousePos.y;

        bool xCheck = x >= -halfSize && x <= halfSize;
        bool yCheck = y >= -halfSize && y <= halfSize;

        return xCheck && yCheck;
    }

    private void OnDrawGizmos()
    {
        if (Cells == null)
            return;

        Draw.FontSize = cellSize;
        float halfCellSize = cellSize * 0.5f;

        foreach (Cell cell in Cells)
        {
            Draw.Rectangle(Vector3.zero, new Rect(cell.cellPos.x - halfCellSize * padding, cell.cellPos.y - halfCellSize * padding, cellSize * padding, cellSize * padding), new Color(1, 1, 1, 0.5f));
            Draw.Text(cell.cellPos, cell.indexStr, new Color(0, 0, 0, 0.5f));
        }
        float hSize = size.x * 0.5f;
        Draw.RectangleBorder(Vector3.zero, new Rect(-hSize, -hSize, size.x, size.x), 0.1f);
    }

    private int GetCellIndex(int r, int c)
    {
        return r * rowCount + c;
    }

    private Vector2Int GetRowCol(Cell cell)
    {
        return new Vector2Int(Mathf.FloorToInt(cell.cellIndex % rowCount), Mathf.FloorToInt(cell.cellIndex / rowCount));
    }

    private bool IsMovesLeft()
    {
        for (int i = 0; i < Cells.Count; i++)
        {
            if (!Cells[i].isOccupied) return true;
        }
        return false;
    }
}