using System;
using DG.Tweening;
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
    [SerializeField] private Image[] knivesImage;
    [SerializeField] private TextMeshProUGUI knifeNameText;
    [SerializeField] private TextMeshProUGUI selectText;
    private RectTransform[] _knivesRectTransform;
    private int _index = 0;
    private int _iterator = 0;
    private void Start()
    {
        _knivesRectTransform = new RectTransform[knivesImage.Length];
        for (int i = 0; i < knivesImage.Length; i++)
        {
            _knivesRectTransform[i] = knivesImage[i].GetComponent<RectTransform>();
        }
        knivesImage[1].DOFade(0, 0);
        _knivesRectTransform[1].DOAnchorPos(new Vector2(-150, 0), 0f);
    }

    private void OnEnable()
    {
        UpdateUI();
    }

    private void UpdateUI(bool right)
    {
        float time = 0.4f;
        float distance = 300f;
        _iterator++;
        knivesImage[_iterator % 2].DOFade(0, time);
        _knivesRectTransform[_iterator % 2].DOAnchorPos(new Vector2(right ? distance : -distance, 0), time);
        knivesImage[(_iterator + 1) % 2].sprite = skins[_index].Skin;
        _knivesRectTransform[(_iterator + 1) % 2].DOAnchorPos(new Vector2(right ? -distance : distance, 0), 0);
        knivesImage[(_iterator + 1) % 2].DOFade(1, time);
        _knivesRectTransform[(_iterator + 1) % 2].DOAnchorPos(new Vector2(0, 0), time);
        knifeNameText.text = skins[_index].Name;
        if (stats.CurrentSkin == skins[_index])
        {
            selectText.text = "Selected";
            return;
        }
        selectText.text = stats.GetList().Contains(skins[_index]) ? "Select" : "Unlock";
    }
    private void UpdateUI()
    {
        knivesImage[_iterator % 2].sprite = skins[_index].Skin;
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
        UpdateUI(true);
    }
    public void PreviousSkin()
    {
        _index--;
        if (_index == -1)
            _index = skins.Length -1;
        UpdateUI(false);
    }
    public void Select()
    {
        if (stats.GetList().Contains(skins[_index]))
        {
            stats.CurrentSkin = skins[_index];
            onSkinChange.Raise();
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
