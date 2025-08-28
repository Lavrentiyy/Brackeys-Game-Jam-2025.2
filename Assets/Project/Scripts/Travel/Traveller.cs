using DG.Tweening;
using UnityEngine;

public class Traveller : MonoBehaviour
{
    private POI travelPOI;
    private Tween moveTween;
    [SerializeField] private float speed;
    [SerializeField] private Ease ease;
    private GameTime gameTime;

    private void Start()
    {
        gameTime = G.Get<GameTime>();
    }

    public void StartTravel(POI poi)
    {
        Debug.Log($"Start travel {poi}");
        moveTween.Kill();
        travelPOI = poi;
        var charGame = GetComponent<CharacterGame>();
        var panel = G.Get<CharacterPanel>();
        panel.SetCharacterTravelButton(charGame, false);
        if (charGame.currentPoi != null)
        {
            charGame.currentPoi.RemoveCharacter(charGame);
        }
        
        moveTween = transform.DOMove(travelPOI.transform.position,
            Vector2.Distance(transform.position, travelPOI.transform.position) / speed).SetEase(ease).OnComplete(() =>
        {
            travelPOI.AddCharacter(charGame);
            panel.SetCharacterTravelButton(charGame, true);
            OnTravelToPoi(travelPOI);
        });
        moveTween.SetUpdate(UpdateType.Manual);
    }

    private void Update()
    {
        moveTween?.ManualUpdate(Time.deltaTime * gameTime.GameTimeScale, 1);
    }

    private void OnTravelToPoi(POI poi)
    {
        if (poi.TryGetComponent<ScavengingPOI>(out var scavengingPoi))
        {
            foreach (var onPoi in GetComponents<IOnScavengerPOIEnter>())
            {
                onPoi.OnScavengerPoiEnter(scavengingPoi);
            }
        }
    }
}
