using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Inventory/Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string itemName; // 아이템 이름
    public Sprite icon; // 아이템 이미지
    public int itemLevel; // 아이템 등급
    public ItemType itemType; // 아이템 타입
    public Vector2Int size; // 아이템의 크기 (가로 x 세로)
    public bool[,] shape; // 아이템의 형태를 정의하는 2D 배열
}
