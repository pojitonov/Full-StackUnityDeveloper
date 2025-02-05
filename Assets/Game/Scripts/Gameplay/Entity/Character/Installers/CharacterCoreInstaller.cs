using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;
        [SerializeField] private Health _health;
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private float _angularSpeed = 3;
        [SerializeField] private WeaponEntity _weapon;
        [SerializeField] private TriggerEventReceiver _trigger;

        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddHealth(_health);
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVector3());
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddWeapon(_weapon);
            entity.AddTrigger(_trigger);
            entity.AddDamageableTag();
            
            //Conditions:
            entity.AddMoveCondition(new AndExpression(entity.IsAlive));
            entity.AddAttackCondition(new BaseFunction<bool>(() => 
                entity.IsAlive() && entity.GetWeapon().GetAttackCondition().Invoke()));

            //Behaviours:
            entity.AddBehaviour<DeathBehaviour>();
            entity.AddBehaviour<MoveTowardsBehaviour>();
            entity.AddBehaviour<RotateTowardsBehaviour>();
            entity.AddBehaviour<InteractBehaviour>();
            entity.AddBehaviour<BodyFallDisableBehaviour>();
            
            //Events:
            entity.AddTakeDamageEvent(new BaseEvent<int>());
            entity.AddDeathEvent(new BaseEvent());
        }
    }
}