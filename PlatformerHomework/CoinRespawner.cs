using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(SpriteRenderer))]

    public class CoinRespawner : MonoBehaviour
    {
        [SerializeField] private int _timeForRespawn;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private IEnumerator Respawn(int timeForRespawn)
        {
            yield return new WaitForSeconds(timeForRespawn);
            _spriteRenderer.enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerMover>() != null)
            {
                _spriteRenderer.enabled = false;
                StartCoroutine(Respawn(_timeForRespawn));
            }
        }
    }
}
