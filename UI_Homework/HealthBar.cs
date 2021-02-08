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

    private Slider _slider;
    private Color _color;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _color = _image.color;
    }

    public void SetupUI(float health, float maxHealth)
    {
        float normalizedHealth = health / maxHealth;
        _image.DOColor(Color.Lerp(Color.red, Color.green, normalizedHealth), _changingDuration);
        _slider.DOValue(normalizedHealth, _changingDuration);
    }
}
