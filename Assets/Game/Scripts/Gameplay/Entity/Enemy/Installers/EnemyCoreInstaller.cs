using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;
        [SerializeField] private Health _health;
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _angularSpeed = 3f;
        [SerializeField] private float _attackRange = 1f;
        [SerializeField] private float _attackInterval = 0.1f;
        
        public override void Install(IEntity entity)
        {
            //Contexts:
            GameContext gameContext = GameContext.Instance;
            
            //Data:
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddHealth(_health);
            entity.AddChasing(new BaseVariable<bool>(false));
            // entity.AddAttacking(new ReactiveBool(false));
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVector3());
            entity.AddDamageableTag();
            entity.AddEnemyTag();
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddTarget(gameContext.GetCharacter());

            //Behaviours:
            entity.AddBehaviour<DeathBehaviour>();
            entity.AddBehaviour<EnemyMoveTowardsBehaviour>();
            entity.AddBehaviour<EnemyRotateBehaviour>();
            entity.AddBehaviour(new AttackBehaviour(_attackRange, _attackInterval));
            entity.AddBehaviour<CountKillsBehaviour>();
            entity.AddBehaviour<BodyFallDisableAnimationBehaviour>();
            
            //Conditions:
            entity.AddMoveCondition(new AndExpression(() => entity.IsAlive() && entity.GetChasing().Value));
            entity.AddRotateCondition(new AndExpression(() => entity.IsAlive() && entity.GetChasing().Value));
            
            //Events:
            entity.AddTakeDamageEvent(new BaseEvent<int>());
            entity.AddDeathEvent(new BaseEvent());
            entity.AddAttackingEvent(new BaseEvent());
        }
    }
}