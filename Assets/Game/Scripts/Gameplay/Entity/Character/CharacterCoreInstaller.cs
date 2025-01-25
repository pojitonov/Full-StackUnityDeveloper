using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;
        [SerializeField] private int _health = 5;
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private float _angularSpeed = 3;
        [SerializeField] private WeaponEntity _weapon;

        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddHealth(new ReactiveVariable<int>(_health));
            entity.AddMoveDirection(new ReactiveVector3());
            entity.AddMoveSpeed(new BaseFunction<float>(() => _moveSpeed));
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddWeapon(_weapon);

            //Conditions:
            entity.AddMoveCondition(new AndExpression(entity.IsAlive));
            
            //Behaviours:
            entity.AddBehaviour<DeathBehaviour>();
            
            //Actions:
            entity.AddMoveAction(new BaseAction<Vector3, float>((direction, deltaTime) =>
            {
                entity.MoveTowards(direction, deltaTime);
                entity.RotateTowards(direction, deltaTime);
            }));
        }
    }
}