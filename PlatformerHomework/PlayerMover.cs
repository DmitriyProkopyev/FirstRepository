using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour, IMover
    {
        [SerializeField] private int _jumpForce;
        [SerializeField] private int _movingSpeed;

        private Rigidbody2D _rigidbody2d;
        private Vector2 _movingDirection;

        public void Jump() => _rigidbody2d.AddForce(new Vector2(0, _jumpForce));

        public bool IsMoving() => _movingDirection != Vector2.zero;

        public void StartMoving() => _rigidbody2d = GetComponent<Rigidbody2D>();

        public void Move()
        {
            _movingDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
            _rigidbody2d.AddForce(_movingDirection * _movingSpeed);
        }
    }
}
