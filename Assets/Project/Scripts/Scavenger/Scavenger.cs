using UniRx;
using UnityEngine;

public class Scavenger : MonoBehaviour, IOnScavengerPOIEnter
{
    private ProgressCircle progressCircle;
    private CharacterGame characterGame;
    private void Start()
    {
        progressCircle = GetComponent<ProgressCircle>();
        characterGame = GetComponent<CharacterGame>();
    }

    public void OnScavengerPoiEnter(ScavengingPOI scavengingPoi)
    {
        progressCircle.OnComplete.Take(1).Subscribe(_ =>
        {
            var eventContext = new EventContext();
            eventContext.character = characterGame;
            characterGame.fullCharacterUI.AddItem(scavengingPoi.GetLoot());
            // scavengingPoi.SetupEvent(eventContext);
            scavengingPoi.GetLoot();
        }).AddTo(this);
        progressCircle.StartProgress(1f);
    }
}
