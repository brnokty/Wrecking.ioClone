using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IncrementalButton : MonoBehaviour
{
    public string name;
    public Sprite incrementalSprite;
    public Image incrementalImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI levelText;
    public GameObject block;
    private int coin => 5 * (gameManager.BallSizeLevel + 1);
    private GameManager gameManager;

    private void Start()
    {
        gameManager = MainManager.Instance.GameManager;
        SetInfos();
        CheckButton();
        MainManager.Instance.EventRunner.UpgradePlayer();
    }


    public void CheckButton()
    {
        if (gameManager.Coin < coin)
        {
            GetComponent<Button>().interactable = false;
            block.SetActive(true);
        }
        else
        {
            GetComponent<Button>().interactable = true;
            block.SetActive(false);
        }
    }

    public void SetInfos()
    {
        nameText.text = name;
        incrementalImage.sprite = incrementalSprite;
        levelText.text = (gameManager.BallSizeLevel + 1).ToString();
        coinText.text = "<sprite index=0> " + coin;
    }

    public void ButtonClick()
    {
        if (gameManager.DecreaseCoin(coin))
        {
            gameManager.BallSizeLevel++;
            SetInfos();
            CheckButton();
            MainManager.Instance.EventRunner.UpgradePlayer();
        }
    }
}