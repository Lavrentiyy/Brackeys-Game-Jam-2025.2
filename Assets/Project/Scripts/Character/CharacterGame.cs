using UnityEngine;
using UnityEngine.UI;

public class CharacterGame : MonoBehaviour
{
    public CharacterData data;
    public POI currentPoi;
    [SerializeField] private Image progressCircle;

    private void Start()
    {
        G.Get<CharacterPanel>().AddCharacter(this);
        G.Get<FullCharacterUIManager>().CreateCharacterFullUI(this);
    }
    
    
}
