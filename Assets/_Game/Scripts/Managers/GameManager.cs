using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Player
    public string Name;
    public Sprite FlagSprite;
    #endregion
    
    private float sensivityValue = 1f;
    private bool GameStarted = false;
    public float GetSensivityValue() => sensivityValue;

    public void SetSensivityValue(float value)
    {
        sensivityValue = value;
        PlayerPrefs.SetFloat("SensivityValue", sensivityValue);
    }

    public void Initialize()
    {
      
        sensivityValue = PlayerPrefs.GetFloat("SensivityValue", 1);
    }
    
    public void SetInfo(string _name, Sprite _flagSprite)
    {
        Name = _name;
        FlagSprite = _flagSprite;
    }

    public bool GetGameStarted() => GameStarted;
    public void SetGameStarted(bool value) => GameStarted = value;

   


}