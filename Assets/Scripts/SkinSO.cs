using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Skin")]
public class SkinSO : ScriptableObject
{
    [SerializeField] private String skinName;
    [SerializeField] private Sprite skin;
    [SerializeField] private bool isUnlocked;
    public String Name
    {
        get => skinName;
        private set => skinName = value;
    }
    public Sprite Skin
    {
        get => skin;
        private set => skin = value;
    }

    public bool Unlocked
    {
        get => isUnlocked;
        set => isUnlocked = value;
    }
}
