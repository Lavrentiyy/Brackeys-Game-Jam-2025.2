using System;
using UnityEngine;

public class EventData : MonoBehaviour
{
    public GameEventType eventType;
    public Sprite eventSprite;
    [TextArea(5, 10)]
    public string eventText;
}

public enum GameEventType
{
    MetalDoor,
}
