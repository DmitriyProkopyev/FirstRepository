using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private float _delay;
    [SerializeField] private Sprite _icon;
    [SerializeField] private RuntimeAnimatorController _animatorController;

    public string Label => _label;
    public int Price => _price;
    public float Delay => _delay;
    public Sprite Icon => _icon;
    public RuntimeAnimatorController Animator => _animatorController;
    public bool IsBought { get; private set; }

    public abstract void Attack(Transform shootPoint);

    public void Buy()
    {
        IsBought = true;
    }
}
