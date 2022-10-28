using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Knife : MonoBehaviour 
{
    [SerializeField] private GameEvent onLoose;
    [SerializeField] private GameEvent onHit;
    [Min(1f)]
    [SerializeField] private float speed = 5f;
    private GameObject _container;
    private Transform _transform;
    private Rigidbody2D _myBody;
    private Vector3 _rotation;
    private bool _onWood;
    private void Awake()
    {
        onLoose.Event += Disable;
    }

    private void Start()
    {
        _transform = transform;
        _onWood = false;
        _myBody = GetComponent<Rigidbody2D>();
        _container = _transform.parent.gameObject;
        _rotation = _transform.eulerAngles;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && !_onWood)
            _myBody.velocity = new Vector3(0f, speed, 0f);
    }
    private void OnTriggerEnter2D(Collider2D target) 
    {
        if(target.CompareTag("Wood")) 
        {
            Debug.Log("Wood");
            gameObject.transform.SetParent(target.transform);
            _myBody.velocity = Vector3.zero;
            _onWood = true;
            onHit.Raise();
        }
        if(target.CompareTag("Knife")) 
        {
            Debug.Log("Knife");
            if(!_onWood)
                onLoose.Raise();
        }
    }

    private void OnEnable()
    {
        if(!_transform)
            return;
        gameObject.transform.SetParent(_container.transform);
        _transform.eulerAngles = _rotation;
        _onWood = false;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}