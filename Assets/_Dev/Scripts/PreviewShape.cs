using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewShape : MonoBehaviour
{
    [SerializeField] private Shape shapePrefab = default;

    private Shape shape;

    public void Init()
    {
        shape = Instantiate(shapePrefab, transform);
        shape.gameObject.SetActive(false);
    }

    public void HandlePreview(Cell cell)
    {
        if (cell != null && cell.isOccupied)
        {
            shape.gameObject.SetActive(false);
            return;
        }
        shape.transform.position = cell.cellPos;
        shape.gameObject.SetActive(true);
    }
}
