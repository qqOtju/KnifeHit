using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private GameStatsSO stats;
    [SerializeField] private GameEvent onSkinChange;
    [SerializeField] private SpriteRenderer knifeSprite;
    private void Awake()
    {
        onSkinChange.Event += OnSkinChangeEvent;
        OnSkinChangeEvent();
    }
    private void OnSkinChangeEvent()
    {
        knifeSprite.sprite = stats.CurrentSkin.Skin;
    }
}
