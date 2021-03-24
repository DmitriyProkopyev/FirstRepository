using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRadius;

    public override void Attack(Transform shootPoint)
    {
        Enemy enemy = FindEnemy(shootPoint);
        if (enemy != null)
            enemy.TakeDamage(_damage);
    }

    private Enemy FindEnemy(Transform attackPoint)
    {
        Collider2D collider = Physics2D.OverlapCircle(attackPoint.position, _attackRadius);
        if (collider != null && collider.gameObject.TryGetComponent(out Enemy enemy))
            return enemy;
        return null;
    }
}
