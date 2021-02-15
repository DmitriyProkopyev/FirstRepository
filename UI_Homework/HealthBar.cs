using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _changingDuration;

    [SerializeField] private float _healingValue;
    [SerializeField] private float _damageValue;

    private Slider _slider;
    private Color _color;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _color = _image.color;
    }

    public void Heal()
    {
        SetupUI(_slider.value + _healingValue);
    }

    public void TakeDamage()
    {
        SetupUI(_slider.value - _damageValue);
    }

    private void SetupUI(float health)
    {
        float maxHealth = _slider.maxValue;
        if (health > maxHealth || health < 0)
            return;

        float normalizedHealth = health / maxHealth;
        _image.DOColor(Color.Lerp(Color.red, Color.green, normalizedHealth), _changingDuration);
        _slider.DOValue(normalizedHealth, _changingDuration);
    }
}
