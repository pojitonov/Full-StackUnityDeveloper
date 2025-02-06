using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class HandAttackUseCase
    {
        public static void Attack(in Vector3 position, in float radius, in int damage, in LayerMask targetLayerMask)
        {
            Collider[] hitColliders = Physics.OverlapSphere(position, radius, targetLayerMask);

            if (hitColliders.Length <= 0) return;
            foreach (var collider in hitColliders)
            {
                if (!collider.FindEntityInParent(out IEntity target)) continue;
                target.TakeDamage(damage);
            }
        }
    }
}