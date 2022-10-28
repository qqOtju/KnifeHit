using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIKnifeShop : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEventSkin onSkinChange;
    [Space(20f)]
    [SerializeField] private SkinSO[] skins;
    [Header("UI")]
    [SerializeField] private Image knifeImage;
    [SerializeField] private TextMeshProUGUI knifeNameText;
    [SerializeField] private TextMeshProUGUI selectText;
    private int _index = 0;

    private void UpdateUI()
    {
        knifeImage.sprite = skins[_index].Skin;
        knifeNameText.text = skins[_index].Name;
        selectText.text = skins[_index].Unlocked ? "Select" : "Unlock";
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
        if (skins[_index].Unlocked)
        {
            onSkinChange.Raise(skins[_index]);
        }
        else
        {
            //ADD
            Debug.Log("ADD");
        }
    }
}
