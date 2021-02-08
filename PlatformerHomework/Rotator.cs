using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Rotator : MonoBehaviour
    {
        private float _lastXPosition;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _lastXPosition = transform.position.x;
        }

        private void Update()
        {
            if (transform.position.x != _lastXPosition)
                _spriteRenderer.flipX = transform.position.x > _lastXPosition;

            _lastXPosition = transform.position.x;
        }
    }
}
