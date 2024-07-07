using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RandomItemSelector : MonoBehaviour
{
    public List<InventoryItemData> allItems; // 모든 아이템 데이터
    public Image[] itemImages; // 미리 준비된 Sprite 3개를 나타내는 Image 배열
    public Button randomizeButton; // 랜덤 버튼

    private void Start()
    {
        randomizeButton.onClick.AddListener(RandomizeItems);
    }

    private void RandomizeItems()
    {
        if (allItems.Count < 3)
        {
            Debug.LogError("There are not enough items in the list to randomize 3 unique items.");
            return;
        }

        List<int> selectedIndices = new List<int>();
        while (selectedIndices.Count < 3)
        {
            int randomIndex = Random.Range(0, allItems.Count);
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            InventoryItemData selectedItem = allItems[selectedIndices[i]];
            itemImages[i].sprite = selectedItem.icon;
            itemImages[i].color = Color.white; // 아이템이 없을 때의 투명도를 초기화
        }
    }
}
