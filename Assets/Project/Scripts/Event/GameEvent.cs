using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoSystem
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TMP_Text mainText;
    [SerializeField] private Image image;
    [SerializeField] private EventChoice eventChoicePrefab;
    [SerializeField] private Transform choicePanel;
    private List<GameObject> deleteOnEvent = new();


    private void Start()
    {
        var eventManager = G.Get<EventManager>();
        eventManager.OnEventStart.Subscribe(_ => canvas.enabled = true).AddTo(this);
        eventManager.OnEventEnd.Subscribe(_ => canvas.enabled = false).AddTo(this);

        eventManager.OnEventStart.Subscribe(ShowEvent);
    }

    private void ShowEvent(EventContext eventContext)
    {
        if(eventContext == null) return;
        foreach (var delete in deleteOnEvent)
        {
            Destroy(delete);
        }
        deleteOnEvent.Clear();
        
        var eventData = eventContext.eventData;
        mainText.SetText(eventData.eventText);
        image.sprite = eventData.eventSprite;

        foreach (var eventAction in eventData.GetComponentsInChildren<EventAction>())
        {
            var newChoice = Instantiate(eventChoicePrefab, choicePanel);
            newChoice.SetupChoice(eventAction.actionText, () => eventAction.OnAction(eventContext));
            deleteOnEvent.Add(newChoice.gameObject);
        }
    }
}
