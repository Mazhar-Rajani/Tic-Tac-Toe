using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Background : MonoBehaviour
{
    [SerializeField] private ColorPallete colorPallete = default;
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private float animTime = default;

    private void Awake()
    {
        RefreshColor(false);
    }

    private void Update()
    {
        Vector2 size = Utility.GetWorldCameraSize();
        transform.localPosition = Vector3.zero;
        transform.localScale = size;
    }

    public void RefreshColor(bool animate)
    {
        Color color = colorPallete.GetRandomColor();
        if (animate)
        {
            spriteRenderer.DOColor(color, animTime);
        }
        else
        {
            spriteRenderer.color = color;
        }
    }
}