using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public interface IHumanoidAnimator
    {
        void Idle();

        void Run();

        void Attack();

        void Jump();

        void Grounded();

        void Die();

        void TakeDamage();

        void Recover();
    }
}
