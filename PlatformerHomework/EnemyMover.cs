using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Platformer
{
    public class EnemyMover : MonoBehaviour, IMover
    {
        [SerializeField] private float _endPointOfPath;
        [SerializeField] private float _goingTime;

        public void StartMoving()
        {
            transform.DOMoveX(_endPointOfPath, _goingTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }

        public bool IsMoving() => true;

        public void Move()
        {

        }

        public void Jump()
        {

        }
    }
}
