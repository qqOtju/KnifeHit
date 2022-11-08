using System;
using UnityEngine;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameStatusEvent onGameStatusChange;
    [SerializeField] private UnityEvent onPause;
    [SerializeField] private UnityEvent onGame;

    private void Awake()
    {
        onGameStatusChange.Event += status =>
        {
            switch (status)
            {
                case GameStatus.Game:
                    onGame?.Invoke();
                    break;
                case GameStatus.Pause:
                    onPause?.Invoke();
                    break;
                case GameStatus.Restart:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        };
    }
}
