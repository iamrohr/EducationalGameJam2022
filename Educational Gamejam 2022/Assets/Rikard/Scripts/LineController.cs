using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Transform[] starPoints;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] points)
    {
        _lineRenderer.positionCount = points.Length;
        this.starPoints = points;
    }

    private void Update()
    {
        for (int i = 0; i < starPoints.Length; i++)
        {
            _lineRenderer.SetPosition(i, starPoints[i].position);
        }
        
    }
}
