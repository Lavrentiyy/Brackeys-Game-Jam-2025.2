using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EventManager : MonoSystem
{
    private GameTime gameTime;
    private Dictionary<GameEventType, EventData> eventDict = new();
    
    public Subject<EventContext> OnEventStart = new();
    public Subject<EventContext> OnEventEnd = new();
    
    private void Start()
    {
        gameTime = G.Get<GameTime>();
        foreach (var eventData in Resources.LoadAll<EventData>("EventData"))
        {
            eventDict.Add(eventData.eventType, eventData);
        }
    }

    public EventData GetEventData(GameEventType gameEventType)
    {
        return eventDict[gameEventType];
    }

    public void StartEvent(EventContext eventContext, GameEventType gameEventType)
    {
        eventContext.eventData = GetEventData(gameEventType);
        OnEventStart.OnNext(eventContext);
        gameTime.SetGameTimeScale(0);
    }

    public void EndEvent(EventContext eventContext)
    {
        OnEventEnd.OnNext(eventContext);
        gameTime.SetGameTimeScale(1);
    }
}
