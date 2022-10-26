using UnityEngine;

public class Wood : MonoBehaviour
{
    //TODO
    //Implement DOTween rotation
    [SerializeField] private int speed = 3;
    void FixedUpdate() 
    {
        transform.Rotate(0f, 0f, speed);
    }
}