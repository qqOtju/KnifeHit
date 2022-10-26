using UnityEngine;

public class UITemp : MonoBehaviour
{
    [SerializeField] private SkinSO skin;
    [SerializeField] private GameEventSkin onSkinChange;

    public void OnClick()
    {
        onSkinChange.Raise(skin);
    }

}
