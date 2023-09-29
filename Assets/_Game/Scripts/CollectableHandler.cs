using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableHandler : MonoBehaviour
{
    [SerializeField] private GameObject objectToDrop;
    [SerializeField] private GameObject coinObject;
    [SerializeField] private LayerMask groundLayer;
    public float dropRadius = 50f;
    [SerializeField] private float minTime = 10f;
    [SerializeField] private float maxTime = 15f;
    private bool isGameStarted;
    private bool isGameFinished;

    private void Start()
    {
        
        MainManager.Instance.EventManager.Register(EventTypes.LevelStart, StartDropBox);
    }

    private void StartDropBox(EventArgs args)
    {
        isGameStarted = true;
        InvokeRepeating("DropBox", Random.Range(minTime, maxTime), Random.Range(minTime, maxTime));
        InvokeRepeating("DropCoin", Random.Range(minTime, maxTime), Random.Range(minTime, maxTime));
    }

    private void DropBox()
    {
        Vector3 randomPosition = RandomPointInRadius(transform.position, dropRadius);

        if (IsGround(randomPosition))
        {
            Instantiate(objectToDrop, randomPosition, Quaternion.identity);
        }
    }
    
    private void DropCoin()
    {
        Vector3 randomPosition = RandomPointInRadius(transform.position, dropRadius);

        if (IsGround(randomPosition))
        {
            Instantiate(coinObject, randomPosition, Quaternion.identity);
        }
    }

    private Vector3 RandomPointInRadius(Vector3 center, float radius)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * radius;
        randomPoint.y = center.y;
        return randomPoint;
    }

    private bool IsGround(Vector3 position)
    {
        Ray ray = new Ray(position + Vector3.up * 100f, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            return true;
        }

        return false;
    }
}