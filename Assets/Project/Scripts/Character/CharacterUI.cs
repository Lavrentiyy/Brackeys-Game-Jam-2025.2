using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public CharacterGame currentCharacter;

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameText;
    public Button travelButton;
    public Button inventoryButton;
    

    private void Start()
    {
        travelButton.OnClickAsObservable().Subscribe(_ => G.Get<TravelManager>().TravelState(currentCharacter))
            .AddTo(this);
        inventoryButton.OnClickAsObservable().Subscribe(_ =>
        {
            G.Get<FullCharacterUIManager>().ShowCharacter(currentCharacter);
        }).AddTo(this);
    }

    public void SetCharacter(CharacterGame characterGame)
    {
        currentCharacter = characterGame;
        icon.sprite = characterGame.data.icon;
        nameText.SetText(characterGame.data.charName);
    }
}
