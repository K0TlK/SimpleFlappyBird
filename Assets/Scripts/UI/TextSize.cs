using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSize : MonoBehaviour
{
    [SerializeField] private float deltaSize = 50.0f;

    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        RectTransform rect = GetComponent<RectTransform>();
        sequence.Append(rect.DOSizeDelta(new Vector2(rect.sizeDelta.x, rect.sizeDelta.y - deltaSize), 1));
        sequence.Append(rect.DOSizeDelta(new Vector2(rect.sizeDelta.x, rect.sizeDelta.y), 1));
        sequence.SetLoops(-1, LoopType.Restart);
    }
}
