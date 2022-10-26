using System;
using TMPro;
using UnityEngine;

public class UIHitCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private GameEvent onLoose;
    [SerializeField] private GameEvent onHit;
    private int _counter;

    private void Awake()
    {
        onHit.Event += OnHitEvent;
        onLoose.Event += OnLooseEvent;
    }

    private void OnLooseEvent()
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
