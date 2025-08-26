using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    private CharacterGame currentCharacter;

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameText;
    
    public void SetCharacter(CharacterGame characterGame)
    {
        currentCharacter = characterGame;
        icon.sprite = characterGame.data.icon;
        nameText.SetText(characterGame.data.charName);
    }
}
