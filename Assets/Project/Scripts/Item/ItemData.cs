using UnityEngine;

public class ItemData : MonoBehaviour
{
    public ItemId itemId;
    public string itemName;
    public Sprite itemIcon;
    public SlotType slotType;
    [Header("Drop")]
    public int itemTier;
    public ItemType itemType;
}

public enum ItemId
{
    //0-100 food
    FoodCan = 0,
    
    //101-200 med
    Bandage = 101,
    
    //201-300 ammo
    PistolAmmo = 201,
    ShotGunAmmo = 202,
    RifleAmmo= 203,
    
    //301-400 cloth
    LeatherJacket = 301,
    
    //401-500 helmet
    MotorcycleHelmet = 401,
    
    //501-600 weapon
    PistolLuger = 501,
}

public enum ItemType
{
    Food,
    Medicine,
    Ammo,
    Cloth,
    Weapon
}
