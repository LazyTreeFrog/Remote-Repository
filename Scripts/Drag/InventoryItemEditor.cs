using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InventoryItemData))]
public class InventoryItemDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InventoryItemData item = (InventoryItemData)target;

        // �⺻ �ʵ��
        item.itemName = EditorGUILayout.TextField("Item Name", item.itemName);
        item.icon = (Sprite)EditorGUILayout.ObjectField("Icon", item.icon, typeof(Sprite), false);
        item.itemLevel = EditorGUILayout.IntField("Item Level", item.itemLevel);
        item.itemType = (ItemType)EditorGUILayout.EnumPopup("Item Type", item.itemType);
        item.size = EditorGUILayout.Vector2IntField("Size", item.size);

        // �迭�� ũ�⸦ �ʱ�ȭ�ϰų� �缳���մϴ�.
        if (item.shape == null || item.shape.GetLength(0) != item.size.y || item.shape.GetLength(1) != item.size.x)
        {
            item.shape = new bool[item.size.y, item.size.x];
        }

        EditorGUILayout.LabelField("Shape");

        // �������� ���¸� �׸���
        for (int y = 0; y < item.size.y; y++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int x = 0; x < item.size.x; x++)
            {
                item.shape[y, x] = EditorGUILayout.Toggle(item.shape[y, x], GUILayout.Width(20));
            }
            EditorGUILayout.EndHorizontal();
        }

        // ������� ����
        if (GUI.changed)
        {
            EditorUtility.SetDirty(item);
        }
    }
}
