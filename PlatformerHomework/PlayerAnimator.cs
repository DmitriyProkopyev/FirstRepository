using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour, IHumanoidAnimator
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Attack() => _animator.SetTrigger("Attack");

        public void Die() => _animator.SetTrigger("Death");

        public void Grounded() => _animator.SetBool("Grounded", true);

        public void Idle() => _animator.SetInteger("AnimState", 0);

        public void Jump() => _animator.SetBool("Grounded", false);

        public void Recover() => _animator.SetTrigger("Recover");

        public void Run() => _animator.SetInteger("AnimState", 2);

        public void TakeDamage() => _animator.SetTrigger("Hurt");
    }
}
