using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    private CharacterGame currentCharacter;

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Button travelButton;

    private void Start()
    {
        travelButton.OnClickAsObservable().Subscribe(_ => G.Get<TravelManager>().TravelState(currentCharacter))
            .AddTo(this);
    }

    public void SetCharacter(CharacterGame characterGame)
    {
        currentCharacter = characterGame;
        icon.sprite = characterGame.data.icon;
        nameText.SetText(characterGame.data.charName);
    }
}
