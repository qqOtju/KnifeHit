using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin Event", menuName = "Events/Skin Event")]
public class GameEventSkin : ScriptableObject
{
    public event Action<SkinSO> Event;

    public void Raise(SkinSO temp)
    {
        Event?.Invoke(temp);
    }
}
