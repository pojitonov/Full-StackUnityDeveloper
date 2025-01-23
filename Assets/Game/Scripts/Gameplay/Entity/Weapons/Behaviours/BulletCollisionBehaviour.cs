using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public class BulletCollisionBehaviour : IEntityInit, IEntityDispose
    {
        private GameObject _gameObject;
        private CollisionEventReceiver _trigger;
        private IValue<int> _damage;
        
        public void Init(in IEntity entity)
        {
            _gameObject = entity.GetGameObject();
            _trigger = entity.GetCollision();
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
                GameObject.Destroy(_gameObject);
            }
        }
    }
}