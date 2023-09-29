using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class MenuPanel : Panel
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_Dropdown countryDropdown;
    [SerializeField] private Slider sensitivitySlider;


    private void Start()
    {
        sensitivitySlider.value = MainManager.Instance.GameManager.GetSensivityValue();
    }


    public void PlayButtonClick()
    {
        MainManager.Instance.GameManager.SetInfo(nameInput.text, countryDropdown.captionImage.sprite);
        MainManager.Instance.EventRunner.LevelStart();
        MainManager.Instance.GameManager.SetSensivityValue(sensitivitySlider.value);
    }
}