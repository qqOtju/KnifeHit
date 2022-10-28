using System;
using UnityEngine;

public class KnifePool : MonoBehaviour 
{
    //TODO
    //Object pool for knifes
    //Separate class for Score UI
    //Add knife shop 
    //Increment wood speed on knife hit
    [Header("Object Pool")]
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private Transform container;
    [SerializeField] private int poolCount = 20;
    [SerializeField] private bool autoExpand = true;
    [Header("Events")]
    [SerializeField] private GameEvent onLoose;
    [SerializeField] private GameEvent onHit;

    private bool _gameIsStarted;
    private PoolMono _pool;

    private void Awake()
    {
        onHit.Event += SpawnKnife;
        onLoose.Event += OnLooseEvent;
    }
    private void Start()
    {
        _pool = new PoolMono(knifePrefab, poolCount, container) {
            autoExpand = autoExpand
        };
    }

    public void StartGame()
    {
        _gameIsStarted = true;
        SpawnKnife();
    }
    private void OnLooseEvent()
    {
        _gameIsStarted = false;
    }
    private void SpawnKnife() 
    {
        if (!_gameIsStarted)
            return;
        GameObject go = _pool.GetFreeElement();
        go.transform.parent = container;
        go.transform.localPosition = new Vector3(0, 0, 0);
    }

}