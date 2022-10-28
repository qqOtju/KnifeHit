using System;
using TMPro;
using UnityEngine;

public class UIHitCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private GameEvent onHit;
    private int _counter;

    private void Awake()
    {
        onHit.Event += OnHitEvent;
    }

    public void OnStartGame()
    {
        _counter = 0;
        counterText.text = _counter.ToString();
    }

    private void OnHitEvent()
    {
        _counter++;
        counterText.text = _counter.ToString();
    }
}
