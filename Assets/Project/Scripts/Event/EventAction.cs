using UnityEngine;

public class EventAction : MonoBehaviour
{
    public string actionText;

    public void OnAction(EventContext eventContext)
    {
        foreach (var eventAction in GetComponentsInChildren<IOnEventAction>())
        {
            eventAction.OnAction(eventContext);
        }
        G.Get<EventManager>().EndEvent(eventContext);
    }
}
