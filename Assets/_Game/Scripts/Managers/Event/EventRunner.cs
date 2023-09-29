using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRunner : MonoBehaviour
{
    #region PUBLIC METHODS

    public void GameStart()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.GameStart, new EventArgs());
    }


    public void LevelStart()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.LevelStart, new IntArgs(PlayerPrefs.GetInt("Level")));
    }


    public void UpgradePlayer()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.UpgradePlayer, new EventArgs());
    }


    public void Finish()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.Finish);
    }

    public void Fail()
    {
        if (MainManager.Instance.GameManager.GetGameFinished())
            return;
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.Fail);
        MainManager.Instance.GameManager.SetGameFinished(true);
    }

    public void Win()
    {
        if (MainManager.Instance.GameManager.GetGameFinished())
            return;
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.Win);
        MainManager.Instance.GameManager.SetGameFinished(true);
    }

    #endregion
}