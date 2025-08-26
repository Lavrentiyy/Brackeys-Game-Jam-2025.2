using DG.Tweening;
using UnityEngine;

public class Traveller : MonoBehaviour
{
    private POI travelPOI;
    private Tween moveTween;
    [SerializeField] private float speed;
    [SerializeField] private Ease ease;
    public void StartTravel(POI poi)
    {
        moveTween.Kill();
        Debug.Log($"{gameObject} start travelling to {poi}");
        travelPOI = poi;
        var charGame = GetComponent<CharacterGame>();
        var panel = G.Get<CharacterPanel>();
        panel.SetCharacterTravelButton(charGame, false);
        // if (charGame.currentPoi != null)
        // {
        //     charGame.currentPoi.RemoveCharacter(charGame);
        // }
        //
        moveTween = transform.DOMove(travelPOI.transform.position,
            Vector2.Distance(transform.position, travelPOI.transform.position) / speed).SetEase(ease).OnComplete(() =>
        {
            // travelPOI.AddCharacter(charGame);
            panel.SetCharacterTravelButton(charGame, true);
        });
    }
}
