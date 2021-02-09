using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Health))]

    public class Humanoid : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;

        private IMover _mover;
        private IHumanoidAnimator _animator;
        private Health _health;

        private bool _isGrounded;

        private void Start()
        {
            _isGrounded = true;

            _mover = GetComponent<IMover>();
            _animator = GetComponent<IHumanoidAnimator>();
            _health = GetComponent<Health>();

            if (_healthBar != null)
                _healthBar.SetupUI(_health.HealthValue, _health.MaxHealth);
            _mover.StartMoving();
            _animator.Idle();
        }

        private void Update()
        {
            _mover.Move();

            if (_isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _mover.Jump();
                    _animator.Jump();
                }

                if (_mover.IsMoving())
                {
                    _mover.Move();
                    _animator.Run();
                }

                else
                    _animator.Idle();
            }
        }

        public void Heal(float value)
        {
            _health.Heal(value);
            _healthBar.SetupUI(_health.HealthValue, _health.MaxHealth);
        }

        public void TakeDamage(float value)
        {
            _health.TakeDamage(value);
            _healthBar.SetupUI(_health.HealthValue, _health.MaxHealth);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.isTrigger)
                _isGrounded = true;
            _animator.Grounded();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.isTrigger)
                _isGrounded = false;
        }
    }
}
