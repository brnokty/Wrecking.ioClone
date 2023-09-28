using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : Panel
{
    public void NextButtonClick()
    {
        MainManager.Instance.LevelManager.RestartLevel();
    }
}