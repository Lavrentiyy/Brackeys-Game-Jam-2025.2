using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class POI : MonoBehaviour
{
    public List<CharacterGame> characters = new();
    private POIManager _poiManager;

    private void Start()
    {
        _poiManager = G.Get<POIManager>();
        _poiManager.RegisterPOI(this);
    }

    public void AddCharacter(CharacterGame characterGame)
    {
        if(characters.Contains(characterGame)) return;
        characters.Add(characterGame);
        characterGame.currentPoi = this;
    }

    public void RemoveCharacter(CharacterGame characterGame)
    {
        characters.Remove(characterGame);
        characterGame.currentPoi = null;
    }

    private void OnMouseUpAsButton()
    {
        var panel = G.Services.Get<CharacterPanel>();
        panel.Clear();
        foreach (var chara in characters)
        {
            panel.AddCharacter(chara);
        }
        _poiManager.OnPOISelected.OnNext(this);
    }
}
