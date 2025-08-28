using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class EventChoice : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private Button button;
    
    public void SetupChoice(string text, Action action)
    {
        tmpText.SetText(text);
        button.OnClickAsObservable().Take(1).Subscribe(_ =>
        {
            action.Invoke();
        }).AddTo(this);
    }
}
