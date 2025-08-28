using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCircle : MonoBehaviour
{
    [SerializeField] private Image circleImage;
    public Subject<Unit> OnComplete = new();
    private Tween tween;
    private GameTime gameTime;

    private void Start()
    {
        gameTime = G.Get<GameTime>();
    }

    public void StartProgress(float time)
    {
        circleImage.DOKill();
        tween = circleImage.DOFillAmount(1, time).OnComplete(()=>
        {
            OnComplete.OnNext(default);
            circleImage.fillAmount = 0;
        });
        tween.SetUpdate(UpdateType.Manual);
    }

    private void Update()
    {
        tween?.ManualUpdate(Time.deltaTime * gameTime.GameTimeScale, 1);
    }
}
