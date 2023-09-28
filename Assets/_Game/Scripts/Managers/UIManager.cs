using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GamePanel GamePanel;
    public MenuPanel MenuPanel;
    public WinPanel winPanel;
    public FailPanel FailPanel;

    public void Initialize()
    {
        MainManager.Instance.EventManager.Register(EventTypes.Win, Win);
        MainManager.Instance.EventManager.Register(EventTypes.Fail, Fail);
    }


    public void Win(EventArgs args)
    {
        GamePanel.Disappear();
        winPanel.Appear();
    }

    public void Fail(EventArgs args)
    {
        GamePanel.Disappear();
        FailPanel.Appear();
    }
}