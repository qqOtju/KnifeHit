using TMPro;
using UnityEngine;

public class UIHitCounter : MonoBehaviour
{
    [SerializeField] private GameStatusEvent onGameStatusChange;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameStatsSO stats;
    [SerializeField] private GameEvent onHit;
    private int _counter;

    private void Awake()
    {
        onHit.Event += OnHitEvent;
        onGameStatusChange.Event += status =>
        {
            if (status == GameStatus.Restart)
                OnStartGame();
        };
    }

    private void OnStartGame()
    {
        _counter = 0;
        scoreText.text = "Score";
        counterText.text = _counter.ToString();
    }

    private void OnHitEvent()
    {
        _counter++;
        if (_counter > stats.Record)
        {
            stats.Record = _counter;
            scoreText.text = "Record";
            counterText.text = _counter.ToString();
            return;
        }
        scoreText.text = "Score";
        counterText.text = _counter.ToString();
    }
}
