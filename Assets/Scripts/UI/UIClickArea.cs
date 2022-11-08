using UnityEngine;

public class UIClickArea : MonoBehaviour
{
    [SerializeField] private GameEvent onClick;

    public void OnClick()
    {
        onClick.Raise();
    }
}
