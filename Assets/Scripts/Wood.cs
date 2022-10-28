using DG.Tweening;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    private Transform _transform;
    private void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate() 
    {
        _transform.DORotate(_transform.eulerAngles + new Vector3(0,0, speed), 1);
    }
}