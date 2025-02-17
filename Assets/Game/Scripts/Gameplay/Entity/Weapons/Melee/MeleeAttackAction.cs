using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class MeleeAttackAction : IAction
    {
        private readonly IEntity _entity;
        private readonly float _stoppingDistance;
        private readonly int _damage;
        private readonly LayerMask _layerMask;

        public MeleeAttackAction(IWeaponEntity entity, float stoppingDistance, int damage, LayerMask layerMask)
        {
            _entity = entity;
            _stoppingDistance = stoppingDistance;
            _damage = damage;
            _layerMask = layerMask;
        }

        public void Invoke()
        {
            AttackUseCase.Attack(_entity, _stoppingDistance, _damage, _layerMask);
        }
    }
}