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
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _angularSpeed = 3f;
        [SerializeField] private float _fireDelay = 0.5f;
        [SerializeField] private WeaponEntity _weapon;
        [SerializeField] private TriggerEventReceiver _trigger;

        public override void Install(IEntity entity)
        {
            //Entity:
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddHealth(_health);
            entity.AddTrigger(_trigger);

            //Move:
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVector3());
            entity.AddMoveCondition(new AndExpression(entity.IsAlive));
            entity.AddBehaviour<MoveTowardsBehaviour>();

            //Rotate:
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddBehaviour<RotateTowardsBehaviour>();

            //Life:
            entity.AddDeathEvent(new BaseEvent<DamageArgs>());
            entity.AddBehaviour<DeathBehaviour>();
            entity.AddTakeDamageEvent(new BaseEvent<DamageArgs>());
            entity.AddBehaviour<BodyFallDisableBehaviour>();

            //Attack:
            entity.AddAttackDelay(new Const<float>(_fireDelay));
            entity.AddWeapon(_weapon);
            entity.AddDamageableTag();
            entity.AddAttackCondition(new BaseFunction<bool>(() =>
                entity.IsAlive() && entity.GetWeapon().GetAttackCondition().Invoke()));

            //Interact:
            entity.AddBehaviour<InteractBehaviour>();
        }
    }
}