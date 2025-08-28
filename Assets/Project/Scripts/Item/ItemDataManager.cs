using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class ItemDataManager : MonoSystem
{
    private Dictionary<ItemId, ItemData> itemDataDict = new();
    public Dictionary<ItemId, ItemData> IIemDataDict => itemDataDict;
    protected override void Awake()
    {
        base.Awake();
        var allItemData = Resources.LoadAll<ItemData>("ItemData");
        foreach (var itemData in allItemData)
        {
            itemDataDict.Add(itemData.itemId, itemData);
        }
    }

    public ItemData GetItemData(ItemId itemId)
    {
        return itemDataDict[itemId];
    }
}
