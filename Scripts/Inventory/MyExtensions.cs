using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtensions
{
    public static bool IsRectTransformInside(RectTransform rectTransform, RectTransform container)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(container, corners[0], null, out Vector2 localPoint);

        Rect rect = container.rect;
        for (int i = 0; i < 4; i++)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(container, corners[i], null, out localPoint);
            if (!rect.Contains(localPoint))
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsPositionWithinRectTransform(Vector2 position, RectTransform rectTransform, Camera camera)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, position, camera);
    }
}
