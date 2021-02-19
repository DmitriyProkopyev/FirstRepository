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
    [SerializeField] private Health _healthToShow;

    private Slider _slider;
    private Color _color;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _color = _image.color;
        _slider.maxValue = _healthToShow.MaxHealth;
        _slider.value = _healthToShow.HealthValue;
    }

    public void OnHealthChanged()
    {
        float health = _healthToShow.HealthValue;
        float maxHealth = _healthToShow.MaxHealth;
        if (health > maxHealth || health < 0)
            return;

        float normalizedHealth = health / maxHealth;
        _image.DOColor(Color.Lerp(Color.red, Color.green, normalizedHealth), _changingDuration);
        _slider.DOValue(health, _changingDuration);
    }
}
