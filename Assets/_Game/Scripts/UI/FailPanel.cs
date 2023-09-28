using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanel : Panel
{
    public void RestartButtonClick()
    {
        MainManager.Instance.LevelManager.RestartLevel();
    }
}
