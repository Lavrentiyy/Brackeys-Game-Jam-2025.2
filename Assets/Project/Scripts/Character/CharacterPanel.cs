using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private List<CharacterUI> charsInPanel = new();
    [SerializeField] private CharacterUI characterUIPrefab;
    [SerializeField] private Transform charHolder;

    private void Awake()
    {
        G.Services.Add(this);
    }

    private void Start()
    {
        Debug.Log(G.Services.Get<CharacterPanel>());
    }

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
