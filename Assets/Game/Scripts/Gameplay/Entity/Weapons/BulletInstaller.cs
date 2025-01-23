using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class BulletInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 5;

        public override void Install(IEntity entity)
        {
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVariable<Vector3>(transform.forward));
            entity.AddTransform(transform);
            entity.AddGameObject(gameObject);
            entity.WhenFixedUpdate(entity.MoveTowardsDirection);
        }
    }
}