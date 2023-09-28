using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AreaCell : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }


    public void GoDown(Color _color)
    {
        _meshRenderer.material.DOColor(_color, 1f).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
        {
            transform.DOMoveY(-2f, 3f);
        });
    }
}