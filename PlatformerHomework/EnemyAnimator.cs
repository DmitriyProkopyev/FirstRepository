using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour, IHumanoidAnimator
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Attack()
        {
            _animator.SetTrigger("Attack");
        }

        public void Die()
        {
            _animator.SetTrigger("Death");
        }

        public void Grounded()
        {

        }

        public void Idle()
        {
            
        }

        public void Jump()
        {
            
        }

        public void Recover()
        {
            _animator.SetTrigger("Recover");
        }

        public void Run()
        {
            _animator.SetInteger("AnimState", 2);
        }

        public void TakeDamage()
        {
            _animator.SetTrigger("Hurt");
        }
    }
}