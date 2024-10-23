using System;
using UnityEngine;

namespace ShootEmUp
{
    public interface IEnemyAttack
    {
        event Action<Vector2, Vector2> OnFire;
        
        void Attack();
    }
}