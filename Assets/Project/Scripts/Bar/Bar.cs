using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public CharacterStatType statType;
    [SerializeField] private Image mainBar;

    public void SetBarAmount(float amount)
    {
        mainBar.fillAmount = amount;
    }
}
