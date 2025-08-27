using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Dragable currentDragable;
    public SlotType slotType;
    public Dragable CurrentDragable => currentDragable;
    private SlotManager slotManager;
    [SerializeField] private float timeToSlot;

    private void Start()
    {
        slotManager = G.Get<SlotManager>();
    }

    public bool TryPlace(Dragable dragable)
    {
        if (currentDragable != null || (slotType != SlotType.Any && slotType != dragable.GetComponent<ItemUI>().itemData.slotType)) return false;
        
        currentDragable = dragable;
        currentDragable.transform.SetParent(transform);
        currentDragable.transform.DOMove(transform.position, 0.1f);
        dragable.prevSlot = this;
        return true;
    }

    public void Take()
    {
        currentDragable = null;
    }
    public void OnDrop(PointerEventData eventData)
    {
        var dragable = eventData.pointerDrag.GetComponent<Dragable>();
        if (dragable != null)
        {
            TryPlace(dragable);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slotManager.currentSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slotManager.currentSlot = null;
    }

    public void SetDraggable(Dragable dragable)
    {
        if(currentDragable != null)
            RemoveDraggable();
        currentDragable = dragable;
    }

    public void RemoveDraggable()
    {
        if(!currentDragable) return;
        currentDragable = null;
    }
}

public enum SlotType
{
    Any,
    Cloth,
    Helmet,
    Weapon,
}
