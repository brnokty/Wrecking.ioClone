using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIArea : MonoBehaviour
{
    [SerializeField] private AIController _aiController;

    private List<Transform> targetList = new List<Transform>();


    private void Update()
    {
        if (targetList.Count <= 0)
            return;

        _aiController.SetTarget(targetList[0]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetList.Add(other.transform);
        }

        if (other.CompareTag("AI"))
        {
            if (other.GetComponent<AIController>() != _aiController)
            {
                targetList.Add(other.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetList.Remove(other.transform);
        }

        if (other.CompareTag("AI"))
        {
            if (other.GetComponent<AIController>() != _aiController)
            {
                targetList.Remove(other.transform);
            }
        }
    }
}