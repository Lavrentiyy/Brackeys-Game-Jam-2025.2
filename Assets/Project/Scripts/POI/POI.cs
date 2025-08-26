using System;
using System.Collections.Generic;
using UnityEngine;

public class POI : MonoBehaviour
{
    public List<CharacterGame> characters = new();

    private void OnMouseUpAsButton()
    {
        Debug.Log("Mouse click");
        var panel = G.Services.Get<CharacterPanel>();
        panel.Clear();
        foreach (var chara in characters)
        {
            panel.AddCharacter(chara);
        }
    }
}
