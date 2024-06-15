using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "ScriptableObjects/EquipmentSO", order = 1)]
public class EquipmentSO : ScriptableObject
{
    private Item _equipedHood;
    private Item _equipedUpperClothes;
    private Item _equipedLowerClothes;
    private Item _equipedWeapon; 

    

    public Item EquipedHood
    {
        get => _equipedHood;
        set => _equipedHood = value;
    }

    public Item EquipedUpperClothes
    {
        get => _equipedUpperClothes;
        set => _equipedUpperClothes = value;
    }

    public Item EquipedLowerClothes
    {
        get => _equipedLowerClothes;
        set => _equipedLowerClothes = value;
    }

    public Item EquipedWeapon
    {
        get => _equipedWeapon;
        set => _equipedWeapon = value;
    }
}

