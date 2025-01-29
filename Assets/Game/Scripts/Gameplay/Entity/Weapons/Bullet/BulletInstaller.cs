using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public class BulletInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _lifetime;
        [SerializeField] private CollisionEventReceiver _collision;

        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddTransform(transform);
            entity.AddGameObject(gameObject);
            entity.AddMoveDirection(new ReactiveVariable<Vector3>());
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.AddDamage(new Const<int>(_damage));
            entity.AddCollision(_collision);
            entity.AddLifetime(new Cooldown(_lifetime, _lifetime));
            entity.AddDestroyAction(new BaseAction((() =>
            {
                SpawnBulletUseCase.UnspawnBullet(GameContext.Instance, entity);
            })));
            
            //Conditions:
            entity.WhenFixedUpdate(entity.MoveTowardsDirection);

            //Behaviours:
            entity.AddBehaviour<BulletCollisionBehaviour>();
            entity.AddBehaviour<BulletLifetimeBehaviour>();
        }
    }
}