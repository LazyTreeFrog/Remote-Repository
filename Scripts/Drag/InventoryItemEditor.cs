using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InventoryItemData))]
public class InventoryItemDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InventoryItemData item = (InventoryItemData)target;

        // 기본 필드들
        item.itemName = EditorGUILayout.TextField("Item Name", item.itemName);
        item.icon = (Sprite)EditorGUILayout.ObjectField("Icon", item.icon, typeof(Sprite), false);
        item.itemLevel = EditorGUILayout.IntField("Item Level", item.itemLevel);
        item.itemType = (ItemType)EditorGUILayout.EnumPopup("Item Type", item.itemType);
        item.size = EditorGUILayout.Vector2IntField("Size", item.size);

        // 배열의 크기를 초기화하거나 재설정합니다.
        if (item.shape == null || item.shape.GetLength(0) != item.size.y || item.shape.GetLength(1) != item.size.x)
        {
            item.shape = new bool[item.size.y, item.size.x];
        }

        EditorGUILayout.LabelField("Shape");

        // 아이템의 형태를 그리기
        for (int y = 0; y < item.size.y; y++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int x = 0; x < item.size.x; x++)
            {
                item.shape[y, x] = EditorGUILayout.Toggle(item.shape[y, x], GUILayout.Width(20));
            }
            EditorGUILayout.EndHorizontal();
        }

        // 변경사항 저장
        if (GUI.changed)
        {
            EditorUtility.SetDirty(item);
        }
    }
}
