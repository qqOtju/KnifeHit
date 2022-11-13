public class GameState : State
{
    private readonly GameStatusEvent _onGameStatusEvent;
    private readonly GameStatsSO _gameStatsSo;
    public GameState(GameManager gameManager, StateMachine stateMachine, GameStatusEvent onGameStatusChange, GameEvent onLoose, GameStatsSO gameStats)
        : base(gameManager, stateMachine, onGameStatusChange)
    {
        _onGameStatusEvent = onGameStatusChange;
        _gameStatsSo = gameStats;
        onLoose.Event += () => stateMachine.ChangeState(gameManager.Pause);
    }

    public override void Enter()
    {
        base.Enter();
        _gameStatsSo.GamesCount++;
        _onGameStatusEvent.Raise(GameStatus.Game);
    }
}
