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
            entity.AddHealth(new ReactiveInt(_health));
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVector3());
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddWeapon(_weapon);
            
            //Conditions:
            entity.AddMoveCondition(new AndExpression(entity.IsAlive));
            entity.AddFireCondition(new BaseFunction<bool>(() => 
                entity.IsAlive() && entity.GetWeapon().GetFireCondition().Invoke()));

            //Behaviours:
            entity.AddBehaviour<DeathBehaviour>();
            entity.AddBehaviour<MoveTowardsBehaviour>();
            entity.AddBehaviour<RotateTowardsBehaviour>();
            
            //Events:
            entity.AddTakeDamageEvent(new BaseEvent<DamageArgs>());
        }
    }
}