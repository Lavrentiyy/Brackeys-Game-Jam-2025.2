using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterConsume : MonoBehaviour, IDropHandler
{
    public CharacterGame characterGame;
    public void OnDrop(PointerEventData eventData)
    {
        var dragable = eventData.pointerDrag.GetComponent<Dragable>();
        if(!dragable.TryGetComponent<ItemUI>(out var itemUI)) return;
        if(!itemUI.itemData.TryGetComponent<ItemRestoreStat>(out var restoreStat)) return;
        
        if (dragable != null && dragable.prevSlot != null)
        {
            dragable.prevSlot.Take();
            Destroy(dragable.gameObject);
            characterGame.GetComponent<CharacterStats>().AddToStat(restoreStat.statType, restoreStat.restoreValue);
        }
    }
}
