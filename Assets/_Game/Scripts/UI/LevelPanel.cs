using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class LevelPanel : Panel
{
    [SerializeField] private ProgressBar levelProgressBar;
    [SerializeField] private TextMeshProUGUI levelText;


    public void SetMaxCount(int _count)
    {
        levelProgressBar.maxCount = _count;
    }

    public void SetLevelProgressBar(int _level, float value)
    {
        levelText.text = _level.ToString();
        levelProgressBar.SetCurrentCount(value);
    }
}