using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyCoreInstaller : SceneEntityInstaller
    {
        private const string FIRE_EVENT = "fire_event";
        
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _center;
        [SerializeField] private Health _health;
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _angularSpeed = 3f;
        [SerializeField] private float _attackDelay = 1f;
        [SerializeField] private float _stoppingDistance = 1f;
        [SerializeField] private WeaponEntity _weapon;

        public override void Install(IEntity entity)
        {
            //Entity:
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_center);
            entity.AddTarget(new Entity());
            entity.AddWeapon(_weapon);
            entity.AddEnemyTag();
            entity.AddDamageableTag();

            //Move:
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVector3());
            entity.AddBehaviour<EnemyMoveBehaviour>();
            entity.AddMoveCondition(new AndExpression(() => entity.IsAlive() && entity.HasTarget()));

            //Rotate:
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddBehaviour<EnemyRotateBehaviour>();
            entity.AddRotateCondition(new AndExpression(() => entity.IsAlive() && entity.HasTarget()));

            //Attack:
            entity.AddAttackAction(new EnemyAttackAction(entity));
            entity.AddAttackDelay(new Const<float>(_attackDelay));
            entity.AddAttackCondition(new BaseFunction<bool>(() => entity.IsAlive() && entity.HasTarget() && entity.GetTarget().IsAlive()));
            entity.AddBehaviour(new EnemyAttackBehaviour(FIRE_EVENT, _stoppingDistance));
            entity.AddAttackEvent(new BaseEvent());
            
            //Life:
            entity.AddHealth(_health);
            entity.AddBehaviour<DeathBehaviour>();
            entity.AddTakeDamageEvent(new BaseEvent<DamageArgs>());
            entity.AddDeathEvent(new BaseEvent<DamageArgs>());
            entity.AddBehaviour<BodyFallDisableBehaviour>();
        }
    }
}