using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class Shape : MonoBehaviour
{
    public ShapeType shapeType = default;
    [SerializeField] private List<ShapeRenderer> shapeList = default;
}

public enum ShapeType
{
    Cross,
    Circle,
}