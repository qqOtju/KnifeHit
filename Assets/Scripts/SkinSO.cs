using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Skin")]
public class SkinSO : ScriptableObject
{
    [SerializeField] private Sprite skin;
    public Sprite Skin 
    { 
        get => skin; 
        private set => skin = value; 
    }
}
