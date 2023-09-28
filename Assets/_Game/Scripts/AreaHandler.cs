using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct AreaCircle
{
    public List<AreaCell> areaParts;

    public void GoDown(Color _color)
    {
        for (int i = 0; i < areaParts.Count; i++)
        {
            areaParts[i].GoDown(_color);
        }
    }
}

public class AreaHandler : MonoBehaviour
{
    [SerializeField] private Color destroyColor;
    [SerializeField] private List<AreaCircle> areaCircles = new List<AreaCircle>();
    [SerializeField] private float startDuration = 10f;
    [SerializeField] private float cellDecreaseDuration = 10f;
    private float timer = 0f;
    private float tempTimer = 0f;


    void Update()
    {
        timer += Time.deltaTime;
        // print("Timer : " + timer);
        if (timer >= startDuration)
            tempTimer += Time.deltaTime;


        if (tempTimer > cellDecreaseDuration)
        {
            DecreaseCell();
        }
    }

    private void DecreaseCell()
    {
        if (areaCircles.Count <= 0)
            return;

        tempTimer = 0f;
        var circle = areaCircles.Last();
        circle.GoDown(destroyColor);
        areaCircles.RemoveAt(areaCircles.Count - 1);
    }
}