using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MeleeAttackUseCase
    {
        public static void Attack(in IEntity attacker, in Vector3 position, in float radius, in int damage, in LayerMask layerMask)
        {
            Collider[] hitColliders = Physics.OverlapSphere(position, radius, layerMask);

            if (hitColliders.Length <= 0) return;
            foreach (var collider in hitColliders)
            {
                if (!collider.FindEntityInParent(out IEntity target)) continue;

                var damageArgs = new DamageArgs
                {
                    source = attacker,
                    damage = damage
                };

                target.TakeDamage(damageArgs);
            }
        }
    }
}