using System;
using UniRx;

[Serializable]
public class CharacterStat
{
    public CharacterStatType statType;
    public FloatReactiveProperty value;
}

public enum CharacterStatType
{
    Health,
    Hunger
}
