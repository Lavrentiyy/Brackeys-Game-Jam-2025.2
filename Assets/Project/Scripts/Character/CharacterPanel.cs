using System.Collections.Generic;
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
}
