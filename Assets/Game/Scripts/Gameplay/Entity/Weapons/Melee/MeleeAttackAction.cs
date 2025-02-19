using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public class MeleeAttackAction : IAction<float>
    {
        private readonly IWeaponEntity _entity;
        private readonly int _damage;
        private readonly LayerMask _layerMask;

        public MeleeAttackAction(IWeaponEntity entity, int damage, LayerMask layerMask)
        {
            _entity = entity;
            _damage = damage;
            _layerMask = layerMask;
        }

        public void Invoke(float stoppingDistance)
        {
            _entity.Attack(stoppingDistance, _damage, _layerMask);
        }
    }
}