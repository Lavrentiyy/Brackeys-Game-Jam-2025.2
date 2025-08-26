using System.Collections.Generic;
using UniRx;

public class POIManager : MonoSystem
{
    public List<POI> allPOI = new();
    public Subject<POI> OnPOISelected = new();

    public void RegisterPOI(POI poi)
    {
        if(allPOI.Contains(poi))
            return;
        allPOI.Add(poi);
    }

    public void UnRegisterPOI(POI poi)
    {
        allPOI.Remove(poi);
    }
    
    public void HighLightPOI()
    {
        
    }
}
