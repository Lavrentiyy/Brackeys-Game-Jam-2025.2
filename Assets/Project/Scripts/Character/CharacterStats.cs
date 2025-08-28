using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private List<CharacterStat> characterStats = new();

    public void LinkBar(Bar bar)
    {
        foreach (var stat in characterStats)
        {
            if(stat.statType != bar.statType) continue;
            stat.value.Subscribe(x => bar.SetBarAmount(x)).AddTo(this);
        }
    }

    public void AddToStat(CharacterStatType statType, float value)
    {
        var stat = characterStats.FirstOrDefault(x => x.statType == statType);
        var newValue = stat.value.Value + value;
        stat.value.Value = Mathf.Clamp(newValue, 0, 1);
    }
}
