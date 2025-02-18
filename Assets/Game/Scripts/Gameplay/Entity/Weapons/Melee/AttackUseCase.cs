using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class AttackUseCase
    {
        public static void Attack(in IEntity entity, in float stoppingDistance, in int damage, in LayerMask layerMask)
        {
            var position = entity.GetTransform().position;
            Collider[] hitColliders = Physics.OverlapSphere(position, stoppingDistance, layerMask);

            if (hitColliders.Length <= 0) 
                return;
            
            foreach (var collider in hitColliders)
            {
                if (!collider.FindEntityInParent(out IEntity target)) 
                    continue;

                var damageArgs = new DamageArgs
                {
                    source = entity,
                    damage = damage
                };

                target.TakeDamage(damageArgs);
            }
        }
        
        public static void Attack(WeaponEntity entity, in float stoppingDistance)
        {
            if (!entity.HasTarget()) return;
            var target = entity.GetRoot().GetTarget();

            if (!target.IsAlive()) return;

            var distance = entity.GetDistance(target);
            if (distance < stoppingDistance)
                entity.GetAttackEvent().Invoke();
        }
    }
}