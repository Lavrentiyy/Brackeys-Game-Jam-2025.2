using UnityEngine;

public class GameTime : MonoSystem
{
    [SerializeField] private float gameTimeScale = 1;
    public float GameTimeScale => gameTimeScale;

    public void SetGameTimeScale(float value)
    {
        gameTimeScale = value;
    }
}
