using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Dragable currentDragable;
    private SlotManager slotManager;
    [SerializeField] private float timeToSlot;

    private void Start()
    {
        slotManager = G.Get<SlotManager>();
    }

    public bool TryPlace(Dragable dragable)
    {
        if (currentDragable != null) return false;
        Debug.Log("Place");
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
        Debug.Log("drop");
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
}
