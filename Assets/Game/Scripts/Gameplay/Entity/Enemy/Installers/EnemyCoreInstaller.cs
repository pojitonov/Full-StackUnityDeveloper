using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _center;
        [SerializeField] private Health _health;
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _angularSpeed = 3f;
        
        [SerializeField] private WeaponEntity _weapon;
        [SerializeField] private float _stoppingDistance = 1f;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _attackInterval = 0.1f;

        public override void Install(IEntity entity)
        {
            GameContext gameContext = GameContext.Instance;

            //Entity:
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_center);
            entity.AddEnemyTag();
            entity.AddDamageableTag();
            entity.AddTarget(gameContext.GetCharacter());
            
            //Move:
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVector3());
            entity.AddIsChasing(new BaseVariable<bool>(false));
            entity.AddBehaviour<EnemyChasingBehaviour>();
            entity.AddMoveCondition(new AndExpression(() => entity.IsAlive() && entity.GetTarget().IsAlive()));
            
            //Rotate:
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddBehaviour<EnemyRotateBehaviour>();
            entity.AddRotateCondition(new AndExpression(entity.IsAlive));
            
            //Life:
            entity.AddHealth(_health);
            entity.AddBehaviour<DeathBehaviour>();
            entity.AddTakeDamageEvent(new BaseEvent<DamageArgs>());
            entity.AddDeathEvent(new BaseEvent<DamageArgs>());
            entity.AddBehaviour<BodyFallDisableBehaviour>();

            //Attack:
            entity.AddWeapon(_weapon);
            entity.AddAttackCondition(new AndExpression(() => entity.IsAlive() && entity.GetTarget().IsAlive()));
            entity.AddAttackAction(new MeleeAttackAction(entity, _center, _stoppingDistance, _damage));
            entity.AddAttackEvent(new BaseEvent());
            entity.AddBehaviour(new AttackBehaviour(_attackInterval));
        }
    }
}