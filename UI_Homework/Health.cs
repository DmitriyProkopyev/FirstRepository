using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private UnityEvent _healthChanged;

    public float HealthValue => _health;
    public float MaxHealth => _maxHealth;

    public void Heal(float value)
    {
        if (value <= 0)
            return;
        _health += value;
        _health = LimitValue(_health, 1, _maxHealth);
        _healthChanged?.Invoke();
    }

    public void TakeDamage(float value)
    {
        if (value <= 0)
            return;
        _health -= value;
        _health = LimitValue(_health, 1, _maxHealth);
        _healthChanged?.Invoke();
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
