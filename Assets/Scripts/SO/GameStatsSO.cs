using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameStats", menuName = "Game Stats")]
public class GameStatsSO : ScriptableObject
{
    [SerializeField] private List<SkinSO> unlockedSkins;
    [SerializeField] private SkinSO currentSkin;
    [SerializeField] private int gamesCount;
    [SerializeField] private int record;

    public void AddToList(SkinSO skin)
    {
        unlockedSkins.Add(skin);
    }
    public List<SkinSO> GetList() => unlockedSkins;
    public SkinSO CurrentSkin 
    { 
        get => currentSkin; 
        set => currentSkin = value; 
    }
    public int GamesCount 
    { 
        get => gamesCount; 
        set => gamesCount = value; 
    }
    public int Record
    {
        get => record;
        set => record = value;
    }
#if UNITY_EDITOR
    [ContextMenu("ResetStats")]
    public void ResetStats()
    {
        currentSkin = unlockedSkins[0];
        unlockedSkins = new List<SkinSO> { currentSkin };
        record = 0;
        gamesCount = 0;
    }
#endif    
}
