using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public float GetMagnitudeToSlot(RectTransform dragRect)
    {
        Vector3 direct = dragRect.position - rectTransform.position;
        float magnitude = Vector3.SqrMagnitude(direct);
        return magnitude;
    }

    public void SnapToSlot(RectTransform targetRect, float duration = 0.2f) => targetRect.DOMove(rectTransform.position, duration).SetEase(Ease.OutSine);
}
