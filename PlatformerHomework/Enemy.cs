using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Platformer
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _end;
        [SerializeField] private float _goingTime;

        private SpriteRenderer _spriteRenderer;
        private bool _isGoing;
        private float _lastXPosition;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _lastXPosition = transform.position.x;
            transform.DOMoveX(_end, _goingTime).SetLoops(-1, LoopType.Yoyo);
        }

        private void Update()
        {
            if (transform.position.x - _lastXPosition < 0)
                _spriteRenderer.flipX = false;
            else if (transform.position.x - _lastXPosition > 0)
                _spriteRenderer.flipX = true;

            _lastXPosition = transform.position.x;
        }
    }
}
