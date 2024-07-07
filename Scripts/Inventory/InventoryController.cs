using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> slotList;
    [SerializeField] private Transform itemArea;

    private void OnEnable()
    {
        DraggableItem.OnDrop += HandleDrop;
    }

    private void OnDisable()
    {
        DraggableItem.OnDrop -= HandleDrop;
    }

    private void HandleDrop(RectTransform dragRect)
    {
        InventorySlot nearSlot = SearchNearSlot(dragRect);
        if (nearSlot == null)
            FailBacking(dragRect);
        else
            nearSlot.SnapToSlot(dragRect);

    }

    private InventorySlot SearchNearSlot(RectTransform dragRect)
    {
        float minDistance = 0.4f;
        InventorySlot nearSlot = slotList.Where(slot => slot.GetMagnitudeToSlot(dragRect) <= minDistance)
        .OrderBy(slot => slot.GetMagnitudeToSlot(dragRect)).FirstOrDefault();
        return nearSlot;
    }

    private void FailBacking(RectTransform dragRect)
    {
        dragRect.DOMove(itemArea.position, 0.5f).SetEase(Ease.OutSine);
    }

}
