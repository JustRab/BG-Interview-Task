using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStatsSO", order = 1)]
public class PlayerStatsSO : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _speed;
    [SerializeField]private int _money;

    public int MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    public int Health
    {
        get => _health;
        set => _health = value;
    }

    public int AttackDamage
    {
        get => _attackDamage;
        set => _attackDamage = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public int Money
    {
        get => _money;
        set => _money = value;
    }

    public void ResetStats()
    {
        _maxHealth = 100;
        _health = 100;
        _attackDamage = 10;
        _speed = 8f;
        _money = 0;
    }

    public void SaveStats(int _maxHealth, int _health, int _attackDamage, float _speed, int _money)
    {
        _maxHealth = MaxHealth;
        _health = Health;
        _attackDamage = AttackDamage;
        _speed = Speed;
        _money = Money;
    }

    
}