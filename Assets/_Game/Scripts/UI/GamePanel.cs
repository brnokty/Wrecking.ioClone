using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : Panel
{
    [SerializeField] private TextMeshProUGUI coinText;


    public void SetCoinUI(int value)
    {
        coinText.text = value.ToString();
    }
}