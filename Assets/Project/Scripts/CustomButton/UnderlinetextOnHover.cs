using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnderlinetextOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text tmp;
    public void OnPointerEnter(PointerEventData eventData)
    {
        var text = tmp.text;
        text = text.Insert(0, "<u>");
        text = text.Insert(text.Length, "</u>");
        tmp.SetText(text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var text = tmp.text;
        text = text.Remove(0, 3);
        text = text.Remove(text.Length - 4, 4);
        tmp.SetText(text);
    }
}
