using UnityEngine;

public class CharacterGame : MonoBehaviour
{
    public CharacterData data;
    public POI currentPoi;
    public FullCharacterUI fullCharacterUI;

    private void Start()
    {
        G.Get<CharacterPanel>().AddCharacter(this);
        G.Get<FullCharacterUIManager>().CreateCharacterFullUI(this);
    }
}
