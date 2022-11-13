using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameStatusEvent onGameStatusChange;
    [SerializeField] private GameStatsSO stats;
    [SerializeField] private GameEvent onLoose;
    [SerializeField] private GameEvent onStart;
    private StateMachine _stateMachine;
    public State Game { get; private set; }
    public State Pause { get; private set; }
    private void Start()
    {
        _stateMachine = new StateMachine();
        Game = new GameState(this, _stateMachine, onGameStatusChange, onLoose, stats);
        Pause = new PauseState(this, _stateMachine, onGameStatusChange, onStart);
        _stateMachine.Initialize(Pause);
    }
    public void StartGame()
    {
        onStart.Raise();
    }
}

