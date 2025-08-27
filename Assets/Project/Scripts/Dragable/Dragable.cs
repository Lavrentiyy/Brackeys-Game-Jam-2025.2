using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Transform dragCanvas;
    [SerializeField] private RectTransform rectTransform;
    private Camera cameraMain;
    private Tween tween;
    public Slot prevSlot;
    [SerializeField] private float backTime = 0.2f;
    [SerializeField] private Ease ease = Ease.InOutBack;
    private void Start()
    {
        cameraMain = Camera.main;
        dragCanvas = G.Get<FullCharacterUIManager>().transform;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        tween.Kill();
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(dragCanvas);
        transform.SetAsLastSibling();
        if (prevSlot == null) return;
        prevSlot.Take();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (prevSlot != null)
        {
            // tween = transform.DOMove(prevSlot.transform.position, backTime).SetEase(ease);
            prevSlot.TryPlace(this);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
