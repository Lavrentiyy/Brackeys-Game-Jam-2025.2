using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCircle : MonoBehaviour
{
    [SerializeField] private Image circleImage;
    public Subject<Unit> OnComplete = new();

    public void StartProgress(float time)
    {
        circleImage.DOKill();
        circleImage.DOFillAmount(1, time).OnComplete(()=>
        {
            OnComplete.OnNext(default);
            circleImage.fillAmount = 0;
        });
    }
}
