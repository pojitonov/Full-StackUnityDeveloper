using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public class BulletInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _lifetime = 1f;
        [SerializeField] private CollisionEventReceiver _collision;

        public override void Install(IEntity entity)
        {
            GameContext gameContext = GameContext.Instance;

            //Entity:
            entity.AddTransform(transform);
            entity.AddGameObject(gameObject);
            
            //Move:
            entity.AddMoveDirection(new ReactiveVariable<Vector3>());
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.WhenFixedUpdate(entity.MoveTowardsDirection);
            
            //Life:
            entity.AddDamage(new Const<DamageArgs>(new DamageArgs
            {
                damage = _damage,
                source = entity
            }));
            entity.AddLifetime(new Cooldown(_lifetime, _lifetime));
            entity.AddBehaviour<LifetimeBehaviour>();
            entity.AddDestroyAction(new BulletUnspawnAction(entity, gameContext));
            
            //Physics:
            entity.AddCollision(_collision);
            entity.AddBehaviour<BulletCollisionBehaviour>();
        }
    }
}