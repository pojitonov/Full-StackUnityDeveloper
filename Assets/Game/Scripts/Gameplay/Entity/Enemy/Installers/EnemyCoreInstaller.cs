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
        [SerializeField] private int _damage = 10;

        public override void Install(IEntity entity)
        {
            //Contexts:
            GameContext gameContext = GameContext.Instance;

            //Data:
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddHealth(_health);
            entity.AddChasing(new BaseVariable<bool>(false));
            entity.AddMoveSpeed(new Const<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVector3());
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddTarget(gameContext.GetCharacter());
            entity.AddDamageableTag();
            entity.AddEnemyTag();

            //Behaviours:
            entity.AddBehaviour<DeathBehaviour>();
            entity.AddBehaviour<EnemyMoveTowardsBehaviour>();
            entity.AddBehaviour<EnemyRotateBehaviour>();
            entity.AddBehaviour(new AttackBehaviour(_attackRange, _attackInterval));
            entity.AddBehaviour<KillsCountBehaviour>();
            entity.AddBehaviour<BodyFallDisableBehaviour>();
            entity.AddBehaviour(new HandAttackBehaviour(_attackRange, _damage));

            //Conditions:
            entity.AddMoveCondition(new AndExpression(() =>
                entity.IsAlive() && entity.GetChasing().Value && gameContext.GetCharacter().IsAlive()));
            entity.AddRotateCondition(new AndExpression(() => entity.IsAlive() && entity.GetChasing().Value));
            entity.AddAttackCondition(new AndExpression(() =>
                entity.IsAlive() && gameContext.GetCharacter().IsAlive()));

            //Events:
            entity.AddTakeDamageEvent(new BaseEvent<int>());
            entity.AddDeathEvent(new BaseEvent());
            entity.AddAttackingEvent(new BaseEvent());
        }
    }
}