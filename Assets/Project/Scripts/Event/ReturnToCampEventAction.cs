using System.Linq;
using UnityEngine;

public class ReturnToCampEventAction : MonoBehaviour, IOnEventAction
{
    public void OnAction(EventContext eventContext)
    {
        eventContext.character.GetComponent<Traveller>().StartTravel(G.Get<POIManager>().allPOI.First(x => x.TryGetComponent<Camp>(out var camp)));
    }
}
