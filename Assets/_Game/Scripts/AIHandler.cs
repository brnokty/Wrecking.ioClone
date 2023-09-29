using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHandler : MonoBehaviour
{
    [SerializeField] private List<AIController> AIs = new List<AIController>();

    public void RemoveAI(AIController _AI)
    {
        if (AIs.Count <= 0)
            return;

        AIs.Remove(_AI);

        if (AIs.Count <= 0)
        {
            MainManager.Instance.EventRunner.Win();
        }
    }
}