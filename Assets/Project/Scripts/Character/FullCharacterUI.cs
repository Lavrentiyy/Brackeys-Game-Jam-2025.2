using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class FullCharacterUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text charName;
    [SerializeField] private List<Slot> slots = new();
    [SerializeField] private Button closeBtn;

    public CharacterGame currentCharacter;

    private void Start()
    {
        closeBtn.OnClickAsObservable().Subscribe(_ =>
        {
            gameObject.SetActive(false);
        }).AddTo(this);
    }

    public void SetCharacter(CharacterGame characterGame)
    {
        currentCharacter = characterGame;
        image.sprite = currentCharacter.data.icon;
        charName.SetText(currentCharacter.data.charName);
    }
}
