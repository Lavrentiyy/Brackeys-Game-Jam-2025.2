using System.Collections.Generic;
using UnityEngine;

public class FullCharacterUIManager : MonoSystem
{
    [SerializeField] private List<FullCharacterUI> uis = new();
    [SerializeField] private FullCharacterUI prefab;
    [SerializeField] private Transform panel;
    
    public void CreateCharacterFullUI(CharacterGame characterGame)
    {
        var newUI = Instantiate(prefab, panel);
        newUI.SetCharacter(characterGame);
        uis.Add(newUI);
        newUI.gameObject.SetActive(false);
    }

    public void ShowCharacter(CharacterGame characterGame)
    {
        foreach (var charUI in uis)
        {
            charUI.gameObject.SetActive(charUI.currentCharacter == characterGame);
        }
    }
}
