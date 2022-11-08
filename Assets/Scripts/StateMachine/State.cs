public abstract class State
{
    private GameManager _gameManager;
    private StateMachine _stateMachine;
    private GameStatusEvent _onGameStatusChange;
    protected State(GameManager gameManager, StateMachine stateMachine, GameStatusEvent onGameStatusChange)
    {
        _gameManager = gameManager;
        _stateMachine = stateMachine;
        _onGameStatusChange = onGameStatusChange;
    }
    public virtual void Enter()
    {
        
    }
    public virtual void Exit()
    {

    }
}