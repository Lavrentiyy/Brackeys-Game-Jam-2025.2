using System.Collections.Generic;
using Random = UnityEngine.Random;

public class LootData : MonoSystem
{
    private ItemDataManager itemDataManager;

    private void Start()
    {
        itemDataManager = G.Get<ItemDataManager>();
    }

    public ItemData GetItemByTypeAndTier(ItemType itemType, int itemTier)
    {
        var validItemList = new List<ItemData>();
        foreach (var itemData in itemDataManager.IIemDataDict.Values)
        {
            if (!(itemData.itemType == itemType && itemData.itemTier == itemTier)) continue;
            validItemList.Add(itemData);
        }

        if (validItemList.Count == 0) return null;
        return validItemList[Random.Range(0, validItemList.Count)];
    }
}
