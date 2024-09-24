using System;
using UnityEngine;

[System.Serializable]
public class Cell : MonoBehaviour
{
    public int cellIndex;
    public string indexStr;
    public Vector3 cellPos;
    public float cellSize;
    public bool isOccupied;

    public void Setup(int index, Vector3 pos, float cellWidth)
    {
        cellIndex = index;
        indexStr = index.ToString();
        cellPos = pos;
        cellSize = cellWidth;
        transform.position = pos;
        transform.localScale = Vector3.one * cellWidth;
    }
}