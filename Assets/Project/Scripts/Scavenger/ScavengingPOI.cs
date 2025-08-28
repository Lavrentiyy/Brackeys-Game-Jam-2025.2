using UnityEngine;

public class ScavengingPOI : MonoBehaviour
{
    public ItemData loot;

    public ItemData GetLoot()
    {
        return loot;
    }

    public void SetupEvent(EventContext eventContext)
    {
        G.Get<EventManager>().StartEvent(eventContext, GameEventType.MetalDoor);
    }
}
