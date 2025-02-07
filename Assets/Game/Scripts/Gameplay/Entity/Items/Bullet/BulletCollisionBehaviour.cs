using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public class BulletCollisionBehaviour : IEntityInit, IEntityDispose
    {
        private CollisionEventReceiver _trigger;
        private IAction _destroyAction;
        private IValue<DamageArgs> _damage;
        
        public void Init(in IEntity entity)
        {
            _trigger = entity.GetCollision();
            _destroyAction = entity.GetDestroyAction();
            _damage = entity.GetDamage();
            
            _trigger.OnEntered += OnCollisionEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _trigger.OnEntered -= OnCollisionEntered;
        }

        private void OnCollisionEntered(Collision other)
        {
     
            if (other.TryGetEntity(out IEntity target) && target.TakeDamage(_damage.Value))
            {
                _destroyAction.Invoke();
            }
        }
    }
}