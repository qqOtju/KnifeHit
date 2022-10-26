using UnityEngine;

public class Knife : MonoBehaviour 
{
    //TODO
    //Events:
    //OnWoodHit(UnityEvent)
    //OnLoose(UnityEvent)
    
    //Dont reload scene on loose
    //Implement DOTween knife movement 
    
    [SerializeField] private float speed = 5f;
    private Rigidbody2D _myBody;
    private KnifeSpawner _knifeSpawner;

    private bool _hit;
    void Start()
    {
        _hit = false;
        _myBody = GetComponent<Rigidbody2D>();
        _knifeSpawner = GameObject.Find("Knife Spawner").GetComponent<KnifeSpawner>();
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && !_hit)
            _myBody.velocity = new Vector3(0f, speed, 0f);
    }
    void OnTriggerEnter2D(Collider2D target) 
    {
        if(target.CompareTag("Wood")) 
        {
            gameObject.transform.SetParent(target.transform);
            _myBody.velocity = Vector3.zero;
            //OnWoodHit?.Invoke();
            _hit = true;
            _knifeSpawner.SpawnKnife();
            _knifeSpawner.IncrementScore();
        }
        if(target.CompareTag("Knife")) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}