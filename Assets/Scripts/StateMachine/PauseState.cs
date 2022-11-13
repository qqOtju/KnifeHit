using UnityEngine;

public class PauseState : State
{
    private readonly GameStatusEvent _onGameStatusEvent;
    
    public PauseState(GameManager gameManager, StateMachine stateMachine, GameStatusEvent onGameStatusChange, GameEvent onStart)
        : base(gameManager, stateMachine, onGameStatusChange)
    {
        _onGameStatusEvent = onGameStatusChange;
        onStart.Event += () => stateMachine.ChangeState(gameManager.Game);
    }
    public override void Enter()
    {
        base.Enter();
        _onGameStatusEvent.Raise(GameStatus.Pause);
    }

    public override void Exit()
    {
        base.Exit();
        _onGameStatusEvent.Raise(GameStatus.Restart);
    }
}