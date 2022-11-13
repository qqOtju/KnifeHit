using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[SelectionBase]
public class Knife : MonoBehaviour 
{
    [Header("Events")]
    [SerializeField] private GameStatusEvent onGameStatusChange;
    [SerializeField] private GameEvent onClick;
    [SerializeField] private GameEvent onLoose;
    [SerializeField] private GameEvent onHit;
    [Header("Effects")]
    [SerializeField] private ParticleSystem woodHitEffect;
    [SerializeField] private ParticleSystem knifeHitEffect;
    [SerializeField] private ParticleSystem trail;
    [Min(1f)][Space(20f)]
    [SerializeField] private float speed = 5f;
    
    private GameObject _container;
    private Transform _transform;
    private Rigidbody2D _rb;
    private Vector3 _rotation;
    private bool _onKnife;
    private bool _onWood;
    private void Awake()
    {
        onGameStatusChange.Event += status =>
        {
            if (status == GameStatus.Restart)
                Disable();
        };
        onClick.Event += OnClickOnEvent;
    }

    private void OnClickOnEvent()
    {
        if(gameObject.activeInHierarchy && !_onKnife && !_onWood)
            _rb.velocity = new Vector3(0f, speed, 0f);
    }

    private void Start()
    {
        _transform = transform;
        _onWood = false;
        _rb = GetComponent<Rigidbody2D>();
        _container = _transform.parent.gameObject;
        _rotation = _transform.eulerAngles;
    }
    private void OnTriggerEnter2D(Collider2D target) 
    {
        if (_onWood || _onKnife) return;
        trail.Stop();
        if(target.CompareTag("Wood"))
        {
            var mainModule = trail.main;
            mainModule.simulationSpeed = 15f;
            woodHitEffect.Play();
            gameObject.transform.SetParent(target.transform);
            _rb.velocity = Vector3.zero;
            _onWood = true;
            onHit.Raise();
        }
        if(target.CompareTag("Knife"))
        {
            knifeHitEffect.Play();
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.velocity = Vector3.zero;
            _rb.AddForce(new Vector2(0, -3f), ForceMode2D.Impulse);
            _rb.AddTorque(Random.Range(3f,6f), ForceMode2D.Impulse);
            _rb.gravityScale = 1;
            Debug.Log("A");
            onLoose.Raise();
            _onKnife = true;
        }
    }
    private void OnEnable()
    {
        if(!_transform)
            return;
        var mainModule = trail.main;
        mainModule.simulationSpeed = 1f;
        _rb.gravityScale = 0;
        gameObject.transform.SetParent(_container.transform);
        _transform.eulerAngles = _rotation;
        _rb.bodyType = RigidbodyType2D.Kinematic;
        trail.Play();
        _onWood = false;
        _onKnife = false;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}