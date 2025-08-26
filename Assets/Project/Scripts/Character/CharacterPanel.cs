using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterPanel : MonoSystem
{
    [SerializeField] private List<CharacterUI> charsInPanel = new();
    [SerializeField] private CharacterUI characterUIPrefab;
    [SerializeField] private Transform charHolder;

    public void Clear()
    {
        foreach (var chara in charsInPanel.ToArray())
        {
            charsInPanel.Remove(chara);
            Destroy(chara.gameObject);
        }
    }

    public void AddCharacter(CharacterGame characterGame)
    {
        var newCharUI = Instantiate(characterUIPrefab, charHolder);
        newCharUI.SetCharacter(characterGame);
        charsInPanel.Add(newCharUI);
    }

    public void SetCharacterShow(CharacterGame characterGame, bool state)
    {
        charsInPanel.First(x => x.currentCharacter == characterGame).gameObject.SetActive(state);
    }

    public void SetCharacterTravelButton(CharacterGame characterGame, bool state)
    {
        charsInPanel.First(x => x.currentCharacter == characterGame).travelButton.gameObject.SetActive(state);
    }
}
