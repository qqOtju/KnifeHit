using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New UnityEvent", menuName = "Events/Unity Event")]
public class UnityGameEvent : ScriptableObject
{
    public UnityEvent Event;

    public void Raise()
    {
        Event?.Invoke();
    }
}