using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    public ItemData itemData;

    public void SetInfo(ItemData data)
    {
        itemData = data;
        itemImage.sprite = data.itemIcon;
    }
}
