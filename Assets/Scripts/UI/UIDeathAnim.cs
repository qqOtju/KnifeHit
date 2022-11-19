using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIDeathAnim : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    private RectTransform _rectTransform;
    private Vector2 _anchorMax;
    private Vector2 _anchorMin;
    private float _duration = 0.5f;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _anchorMax = _rectTransform.anchorMax;
        _anchorMin = _rectTransform.anchorMin;
    }

    private void OnEnable()
    {
        _rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        _rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        _rectTransform.DOAnchorMax(_anchorMax, _duration).SetEase(animationCurve);
        _rectTransform.DOAnchorMin(_anchorMin, _duration).SetEase(animationCurve);
    }
}
