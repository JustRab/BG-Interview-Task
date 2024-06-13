using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "ScriptableObjects/EquipmentSO", order = 1)]
public class EquipmentSO : ScriptableObject
{
    [Header("Equiped Equipment")]
    private GameObject _equipedHood;
    private GameObject _equipedUpperClothes;
    private GameObject _equipedLowerClothes;
    private GameObject _equipedWeapon; 

    public GameObject EquipedHood
    {
        get => _equipedHood;
        set => _equipedHood = value;
    }

    public GameObject EquipedUpperClothes
    {
        get => _equipedUpperClothes;
        set => _equipedUpperClothes = value;
    }

    public GameObject EquipedLowerClothes
    {
        get => _equipedLowerClothes;
        set => _equipedLowerClothes = value;
    }

    public GameObject EquipedWeapon
    {
        get => _equipedWeapon;
        set => _equipedWeapon = value;
    }
}

