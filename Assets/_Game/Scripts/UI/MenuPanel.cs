using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuPanel : Panel
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_Dropdown countryDropdown;


    public void PlayButtonClick()
    {
        MainManager.Instance.GameManager.SetInfo(nameInput.text, countryDropdown.captionImage.sprite);
        MainManager.Instance.EventRunner.LevelStart();
    }
}