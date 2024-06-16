using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemSO")]
public class Item : ScriptableObject
{

    public string itemName;
    public Sprite itemSprite;
    public int itemPrice;
    public EquipmentType equipmentType;

    public int healthBonus;
    public int attackBonus;
    public int speedBonus;

}

public enum EquipmentType
{
    Hood,
    UpperClothes,
    LowerClothes,
    Weapon
}
