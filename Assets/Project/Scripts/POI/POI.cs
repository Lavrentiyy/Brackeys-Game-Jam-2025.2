using System;
using System.Collections.Generic;
using UnityEngine;

public class POI : MonoBehaviour
{
    public List<CharacterGame> characters = new();
    private POIManager _poiManager;

    private void Start()
    {
        _poiManager = G.Get<POIManager>();
        _poiManager.RegisterPOI(this);
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Mouse click");
        var panel = G.Services.Get<CharacterPanel>();
        panel.Clear();
        foreach (var chara in characters)
        {
            panel.AddCharacter(chara);
        }
        _poiManager.OnPOISelected.OnNext(this);
    }
}
