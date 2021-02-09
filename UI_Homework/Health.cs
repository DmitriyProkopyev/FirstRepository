using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    public float HealthValue => _health;
    public float MaxHealth => _maxHealth;

    public void Heal(float value)
    {
        if (value <= 0)
            return;
        _health += value;
        _health = LimitValue(_health, 1, _maxHealth);
    }

    public void TakeDamage(float value)
    {
        if (value <= 0)
            return;
        _health -= value;
        _health = LimitValue(_health, 1, _maxHealth);
    }

    private float LimitValue(float value, float minLimit, float maxLimit)
    {
        if (value < minLimit)
            return minLimit;
        if (value > maxLimit)
            return maxLimit;
        return value;
    }
}
