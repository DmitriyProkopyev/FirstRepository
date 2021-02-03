using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]

    public class CharacterMover : MonoBehaviour
    {
        [SerializeField] private int _jumpForce;
        [SerializeField] private int _movingSpeed;

        private Rigidbody2D _rigidbody2d;
        private Vector2 _movingDirection;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private bool _isGrounded;

        private void Start()
        {
            _rigidbody2d = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _isGrounded = true;
        }

        private void Update()
        {
            _movingDirection = new Vector2(Input.GetAxis("Horizontal"), 0);

            RotateCharacter(_movingDirection);

            if (_movingDirection == Vector2.zero)
                SetAnimation(AnimationState.Idle);
            else
                SetAnimation(AnimationState.Run);

            if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
                Jump();

            if (_isGrounded && Input.GetKeyDown(KeyCode.Mouse0))
                Attack();

            if (_isGrounded && Input.GetKeyDown(KeyCode.E))
                Die();

            if (_isGrounded && Input.GetKeyDown(KeyCode.R))
                Recover();

            if (_isGrounded && Input.GetKeyDown(KeyCode.T)) 
                TakeDamage();

            _rigidbody2d.AddForce(_movingDirection * _movingSpeed);
        }

        private void Jump()
        {
            _rigidbody2d.AddForce(new Vector2(0, _jumpForce));
            //SetAnimation(AnimationState.Jump);
        }

        private void Attack()
        {
            SetAnimation(AnimationState.Attack);
        }

        private void Die()
        {
            SetAnimation(AnimationState.Death);
        }

        private void TakeDamage()
        {
            SetAnimation(AnimationState.Hurt);
        }

        private void Recover()
        {
            SetAnimation(AnimationState.Recover);
        }

        private void RotateCharacter(Vector2 direction)
        {
            if (direction.x < 0)
            {
                _spriteRenderer.flipX = false;
            }

            if (direction.x > 0)
            {
                _spriteRenderer.flipX = true;
            }
        }

        private void SetAnimation(AnimationState animationState)
        {
            switch (animationState)
            {
                case AnimationState.Idle:
                    _animator.SetInteger("AnimState", 0);
                    break;
                case AnimationState.Run:
                    _animator.SetInteger("AnimState", 2);
                    break;
                case AnimationState.Attack:
                    _animator.SetTrigger("Attack");
                    break;
                case AnimationState.Jump:
                    _animator.SetBool("Grounded", false);
                    break;
                case AnimationState.Grounded:
                    _animator.SetBool("Grounded", true);
                    break;
                case AnimationState.Death:
                    _animator.SetTrigger("Death");
                    break;
                case AnimationState.Recover:
                    _animator.SetTrigger("Recover");
                    break;
                case AnimationState.Hurt:
                    _animator.SetTrigger("Hurt");
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.isTrigger)
            {
                _isGrounded = true;
                SetAnimation(AnimationState.Grounded);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.isTrigger)
            {
                _isGrounded = false;
                SetAnimation(AnimationState.Jump);
            }
        }

        private enum AnimationState
        {
            Idle,
            Run,
            Attack,
            Jump,
            Grounded,
            Death,
            Recover,
            Hurt
        }
    }
}
