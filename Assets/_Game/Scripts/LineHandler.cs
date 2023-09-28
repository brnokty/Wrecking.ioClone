using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHandler : MonoBehaviour
{
    [SerializeField] private Transform hookPosTransform;
    [SerializeField] private Transform ballTransform;
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        _lineRenderer.SetPosition(0, hookPosTransform.position);
        _lineRenderer.SetPosition(1, ballTransform.position);
    }
}