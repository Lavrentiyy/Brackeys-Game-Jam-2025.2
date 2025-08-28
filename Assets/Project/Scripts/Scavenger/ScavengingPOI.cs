using System;
using UnityEngine;

public class ScavengingPOI : MonoBehaviour
{
    [SerializeField] private ItemType lootType;
    [SerializeField] protected int lootTier;

    private LootData lootData;

    private void Start()
    {
        lootData = G.Get<LootData>();
    }

    public ItemData GetLoot()
    {
        return lootData.GetItemByTypeAndTier(lootType, lootTier);
    }

    public void SetupEvent(EventContext eventContext)
    {
        G.Get<EventManager>().StartEvent(eventContext, GameEventType.MetalDoor);
    }
    
    
}
