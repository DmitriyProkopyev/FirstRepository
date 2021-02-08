using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealthLimit;
    [SerializeField] private HealthBar _healthBar;

    public void Heal(float value)
    {
        _health += value;
        _health = LimitValue(_health, 1, _maxHealthLimit);
        _healthBar.SetupUI(_health, _maxHealthLimit);
    }

    public void TakeDamage(float value)
    {
        _health -= value;
        _health = LimitValue(_health, 1, _maxHealthLimit);
        _healthBar.SetupUI(_health, _maxHealthLimit);
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
