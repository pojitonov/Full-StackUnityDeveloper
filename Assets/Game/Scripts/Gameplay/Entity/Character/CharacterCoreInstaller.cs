using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private float _angularSpeed = 3;
        [SerializeField] private int _health = 5;

        public override void Install(IEntity entity)
        {
            entity.AddTransform(transform);
            entity.AddMoveSpeed(new BaseFunction<float>(() => _moveSpeed));
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddHealth(new BaseVariable<int>(_health));

            entity.AddMoveAction(new BaseAction<Vector3, float>((direction, deltaTime) =>
            {
                entity.MoveTowards(direction, deltaTime);
                entity.RotateTowards(direction, deltaTime);
            }));
        }
    }
}