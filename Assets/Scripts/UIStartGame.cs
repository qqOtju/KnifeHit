using UnityEngine;
using UnityEngine.Events;

public class UIStartGame : MonoBehaviour
{
    [SerializeField] private UnityEvent onStartGame;
    [SerializeField] private GameEvent onLoose;

    private void Awake()
    {
        onLoose.Event += OnLooseEvent;
    }

    private void OnLooseEvent()
    {
        gameObject.SetActive(true);
    }

    public void Raise()
    {
        onStartGame?.Invoke();
        gameObject.SetActive(false);
    }
    
}
