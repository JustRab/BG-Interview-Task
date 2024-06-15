using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemSO")]
public class Item : ScriptableObject
{

    public string itemName;
    public Sprite itemSprite;
    public EquipmentType equipmentType;

}

public enum EquipmentType
{
    Hood,
    UpperClothes,
    LowerClothes,
    Weapon
}
