using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AreaCell : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Color baseColor;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        baseColor = _meshRenderer.material.color;
    }


    public void GoDown()
    {
        _meshRenderer.material.DOColor(baseColor, 1f).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
        {
            transform.DOMoveY(-10f, 10f);
        });
    }

    public void DyeCell(Color _color)
    {
        _meshRenderer.material.DOColor(_color, 0.5f);
        gameObject.layer = 0;
    }
}