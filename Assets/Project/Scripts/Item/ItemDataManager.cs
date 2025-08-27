using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoSystem
{
    private Dictionary<ItemType, ItemData> itemDataDict = new();
    protected override void Awake()
    {
        base.Awake();
        var allItemData = Resources.LoadAll<ItemData>("ItemData");
        foreach (var itemData in allItemData)
        {
            itemDataDict.Add(itemData.itemId, itemData);
        }
    }

    public ItemData GetItemData(ItemType itemType)
    {
        return itemDataDict[itemType];
    }
}
