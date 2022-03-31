using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorPallete", menuName = "TicTacToe/Create New Color Pallete")]
public class ColorPallete : ScriptableObject
{
    public List<Color> colors = default;

    public Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }
}