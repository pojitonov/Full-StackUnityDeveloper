using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 3;
        [SerializeField] private float _rotationSpeed = 3;

        public override void Install(IEntity entity)
        {
            entity.AddTransform(transform);
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddAngularSpeed(_rotationSpeed);
        }
    }
}