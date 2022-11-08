using UnityEngine;

public class GameState : State
{
    private readonly GameStatusEvent _onGameStatusEvent;
    public GameState(GameManager gameManager, StateMachine stateMachine, GameStatusEvent onGameStatusChange, GameEvent onLoose)
        : base(gameManager, stateMachine, onGameStatusChange)
    {
        _onGameStatusEvent = onGameStatusChange;
        onLoose.Event += () => stateMachine.ChangeState(gameManager.Pause);
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Game");
        _onGameStatusEvent.Raise(GameStatus.Game);
    }
    public override void Exit()
    {
        base.Exit();
        Debug.Log("Game Exit");
    }
}
