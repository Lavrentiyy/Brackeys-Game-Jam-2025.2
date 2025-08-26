using UnityEngine;

public class Traveller : MonoBehaviour
{
    public void StartTravel(POI poi)
    {
        Debug.Log($"{gameObject} start travelling to {poi}");
    }
}
