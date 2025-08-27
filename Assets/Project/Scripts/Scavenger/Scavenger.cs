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
            characterGame.fullCharacterUI.AddItem(scavengingPoi.GetLoot());
        }).AddTo(this);
        progressCircle.StartProgress(1f);
    }
}
