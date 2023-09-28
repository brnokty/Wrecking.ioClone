using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : Panel
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image flagImage;


    public void SetInfo(string _name, Sprite _flagSprite)
    {
        nameText.text = _name;
        flagImage.sprite = _flagSprite;
    }
}