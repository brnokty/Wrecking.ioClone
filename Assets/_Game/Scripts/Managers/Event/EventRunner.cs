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


    public void UpgradePlayer(bool value)
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.UpgradePlayer, new BoolArgs(value));
    }


    public void Finish()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.Finish);
    }

    public void Fail()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.Fail);
    }

    public void Win()
    {
        MainManager.Instance.EventManager.InvokeEvent(EventTypes.Win);
    }

    #endregion
}