using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private GameEventSkin onSkinChange;
    [SerializeField] private SpriteRenderer knifeSprite;
    private void Awake()
    {
        onSkinChange.Event += OnSkinChangeEvent;
    }
    private void OnSkinChangeEvent(SkinSO obj)
    {
        knifeSprite.sprite = obj.Skin;
    }
}
