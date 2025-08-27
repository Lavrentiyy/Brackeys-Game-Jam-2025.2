using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class FullCharacterUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text charName;
    [SerializeField] private List<Slot> slots = new();
    [SerializeField] private Button closeBtn;
    [SerializeField] private ItemUI itemUIPrefab;

    public CharacterGame currentCharacter;

    private void Start()
    {
        closeBtn.OnClickAsObservable().Subscribe(_ =>
        {
            gameObject.SetActive(false);
        }).AddTo(this);
    }

    public void SetCharacter(CharacterGame characterGame)
    {
        currentCharacter = characterGame;
        currentCharacter.fullCharacterUI = this;
        image.sprite = currentCharacter.data.icon;
        charName.SetText(currentCharacter.data.charName);
    }

    public void AddItem(ItemData itemData)
    {
        if(!TryGetFreeSlot(itemData, out var slot)) return;

        var newItemUI = Instantiate(itemUIPrefab);
        newItemUI.SetInfo(itemData);
        slot.TryPlace(newItemUI.GetComponent<Dragable>());
    }

    private bool TryGetFreeSlot(ItemData itemData, out Slot freeSlot)
    {
        foreach (var slot in slots)
        {
            if(slot.CurrentDragable != null || (slot.slotType != SlotType.Any && itemData.slotType != slot.slotType)) continue;
            freeSlot = slot;
            return true;
        }
        freeSlot = null;
        return false;
    }
}
