using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Gameplay.Entity.Enemy;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;
        [SerializeField] private int _health = 5;
        [SerializeField] private float _angularSpeed = 3;
        
        public override void Install(IEntity entity)
        {
            //Contexts:
            GameContext gameContext = GameContext.Instance;
            
            //Data:
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddHealth(new ReactiveVariable<int>(_health));
            entity.AddDamageableTag();
            entity.AddEnemyTag();
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddTarget(new ReactiveVariable<IEntity>(gameContext.GetCharacter()));

            //Behaviours:
            entity.AddBehaviour<DeathBehaviour>();
            entity.AddBehaviour<KillsCountBehaviour>();
            entity.AddBehaviour<EnemyLookAtBehaviour>();
            entity.AddBehaviour<BodyDisableBehaviour>();
            
            //Events:
            entity.AddTakeDamageEvent(new BaseEvent<int>());
            entity.AddDeathEvent(new BaseEvent());
        }
    }
}