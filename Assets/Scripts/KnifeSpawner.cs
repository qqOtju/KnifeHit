using UnityEngine;
using UnityEngine.UI;

public class KnifeSpawner : MonoBehaviour 
{
    //TODO
    //Object pool for knifes
    //Separate class for Score UI
    //Add knife shop 
    //Increment wood speed on knife hit
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject knifePrefab;

    private Text _scoreText;
    private int _score;

    void Start()
    {
        //_scoreText = GameObject.Find("Score Text").GetComponent<Text>();
    }

    public void SpawnKnife() 
    {
        GameObject go = Instantiate(knifePrefab, spawnPoint.position, spawnPoint.rotation);
        go.transform.parent = spawnPoint;
    }
    
    public void IncrementScore() 
    {
        _score++;
        //_scoreText.text = _score.ToString();
    }
}