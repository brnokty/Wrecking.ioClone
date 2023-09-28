using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct AreaCircle
{
    public List<AreaCell> areaParts;


    public IEnumerator OneBYOneGODown(Color _color, AreaHandler _areaHandler)
    {
        for (int i = 0; i < areaParts.Count; i++)
        {
            areaParts[i].DyeCell(_color);
        }

        yield return new WaitForSeconds(3f);
        for (int i = 0; i < areaParts.Count; i++)
        {
            areaParts[i].GoDown();
            yield return new WaitForSeconds(0.02f);
        }

        _areaHandler.isDestroyed = true;
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

    [HideInInspector] public bool isDestroyed = true;


    void Update()
    {
        if (!isDestroyed)
            return;

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
        isDestroyed = false;

        tempTimer = 0f;
        var circle = areaCircles.Last();
        StartCoroutine(circle.OneBYOneGODown(destroyColor, this));
        areaCircles.RemoveAt(areaCircles.Count - 1);
    }
}