using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class PistolFireAction : IAction
    {
        private readonly IWeaponEntity _entity;

        public PistolFireAction(IWeaponEntity entity)
        {
            _entity = entity;
        }

        public void Invoke()
        {
            if (_entity.GetFireCondition().Invoke())
            {
                _entity.FireBullet(GameContext.Instance);
                _entity.GetFireEvent().Invoke();
            }
        }
    }
}