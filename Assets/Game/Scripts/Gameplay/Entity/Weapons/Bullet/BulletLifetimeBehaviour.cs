using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public class BulletLifetimeBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private Cooldown _lifetime;
        private IAction _destroyAction;
        
        public void Init(in IEntity entity)
        {
            _lifetime = entity.GetLifetime();
            _destroyAction = entity.GetDestroyAction();
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            _lifetime.Tick(deltaTime);
            if(_lifetime.IsExpired())
                _destroyAction.Invoke();
        }
    }
}