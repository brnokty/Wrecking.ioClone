using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Player

    public string Name;
    public Sprite FlagSprite;

    #endregion

    private int coin = 0;
    private float sensivityValue = 1f;
    private bool GameStarted = false;
    private bool GameFinished = false;


    #region Incremental

    public int BallSizeLevel = 0;

    #endregion

    public float GetSensivityValue() => sensivityValue;

    public void SetSensivityValue(float value)
    {
        sensivityValue = value;
        PlayerPrefs.SetFloat("SensivityValue", sensivityValue);
    }

    public void Initialize()
    {
        sensivityValue = PlayerPrefs.GetFloat("SensivityValue", 1);
        coin = PlayerPrefs.GetInt("Coin", 0);
        MainManager.Instance.UIManager.GamePanel.SetCoinUI(coin);
    }

    public void IncreaseCoin(int value)
    {
        coin += value;
        PlayerPrefs.SetInt("Coin", coin);
        MainManager.Instance.UIManager.GamePanel.SetCoinUI(coin);
    }


    public int Coin => coin;

    public bool DecreaseCoin(int value)
    {
        if (coin >= value)
        {
            coin -= value;
            PlayerPrefs.SetInt("Coin", coin);
            MainManager.Instance.UIManager.GamePanel.SetCoinUI(coin);
            return true;
        }

        return false;
    }

    public void SetInfo(string _name, Sprite _flagSprite)
    {
        Name = _name;
        FlagSprite = _flagSprite;
    }

    public bool GetGameStarted() => GameStarted;
    public void SetGameStarted(bool value) => GameStarted = value;

    public bool GetGameFinished() => GameFinished;
    public void SetGameFinished(bool value) => GameFinished = value;
}