using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RandomItemSelector : MonoBehaviour
{
    public List<InventoryItemData> allItems; // ��� ������ ������
    public Image[] itemImages; // �̸� �غ�� Sprite 3���� ��Ÿ���� Image �迭
    public Button randomizeButton; // ���� ��ư

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
            itemImages[i].color = Color.white; // �������� ���� ���� ������ �ʱ�ȭ
        }
    }
}
