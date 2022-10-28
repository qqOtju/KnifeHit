using UnityEngine;
using UnityEngine.Events;

public class UIStartGame : MonoBehaviour
{
    [SerializeField] private UnityEvent onStartGame;
    [SerializeField] private UnityEvent onLooseGame;
    [SerializeField] private GameEvent onLoose;

    private void Awake()
    {
        onLoose.Event += OnLooseEvent;
    }

    private void OnLooseEvent()
    {
        onLooseGame?.Invoke();
        gameObject.SetActive(true);
    }

    public void Raise()
    {
        onStartGame?.Invoke();
        gameObject.SetActive(false);
    }
    
}
