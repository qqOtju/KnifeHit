using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIKnifeShop : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvent onSkinChange;
    [Space(20f)]
    [SerializeField] private SkinSO[] skins;
    [Space(20f)]
    [SerializeField] private GameStatsSO stats;
    [Header("UI")]
    [SerializeField] private Image knifeImage;
    [SerializeField] private TextMeshProUGUI knifeNameText;
    [SerializeField] private TextMeshProUGUI selectText;
    private int _index = 0;

    private void OnEnable()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        knifeImage.sprite = skins[_index].Skin;
        knifeNameText.text = skins[_index].Name;
        if (stats.CurrentSkin == skins[_index])
        {
            selectText.text = "Selected";
            return;
        }
        selectText.text = stats.GetList().Contains(skins[_index]) ? "Select" : "Unlock";
    }

    public void NextSkin()
    {
        _index++;
        if (_index == skins.Length)
            _index = 0;
        UpdateUI();
    }
    public void PreviousSkin()
    {
        _index--;
        if (_index == -1)
            _index = skins.Length -1;
        UpdateUI();
    }
    public void Select()
    {
        if (stats.GetList().Contains(skins[_index]))
        {
            stats.CurrentSkin = skins[_index];
            onSkinChange.Raise();/*
            selectText.text = "Selected";*/
            UpdateUI();
        }
        else
        {
            //ADD
            stats.AddToList(skins[_index]);
            UpdateUI();
        }
    }
}
