using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Modules.Gameplay;

namespace Game.Gameplay
{
    // TODO: Fix bug with bullet move
    public class BulletInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private int _damage = 1;
        [SerializeField] private CollisionEventReceiver _collision;

        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddTransform(transform);
            entity.AddGameObject(gameObject);
            entity.AddMoveDirection(new ReactiveVariable<Vector3>(transform.forward));
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.AddDamage(new Const<int>(_damage));
            entity.AddCollision(_collision);

            //Conditions:
            entity.WhenFixedUpdate(entity.MoveTowardsDirection);

            //Behaviours:
            entity.AddBehaviour<BulletCollisionBehaviour>();
        }
    }
}