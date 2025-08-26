using System;
using UniRx;

public class TravelManager : MonoSystem
{
    private IDisposable travelChoosePoiDisposable = Disposable.Empty;
    
    public void TravelState(CharacterGame characterGame)
    {
        UnTravelState();
        travelChoosePoiDisposable = G.Get<POIManager>().OnPOISelected
            .Subscribe(x =>
            {
                characterGame.GetComponent<Traveller>().StartTravel(x);
                UnTravelState();
            });
    }

    public void UnTravelState()
    {
        travelChoosePoiDisposable.Dispose();
    }
}
