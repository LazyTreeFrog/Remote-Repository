using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Inventory/Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string itemName; // ������ �̸�
    public Sprite icon; // ������ �̹���
    public int itemLevel; // ������ ���
    public ItemType itemType; // ������ Ÿ��
    public Vector2Int size; // �������� ũ�� (���� x ����)
    public bool[,] shape; // �������� ���¸� �����ϴ� 2D �迭
}
