using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;
        [SerializeField] private int _health = 5;
        [SerializeField] private float _angularSpeed = 3;
        [SerializeField] private SceneEntity _target;
        
        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddHealth(new ReactiveVariable<int>(_health));
            entity.AddDamageableTag();
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddTarget(new ReactiveVariable<IEntity>(_target));

            //Behaviours:
            entity.AddBehaviour<DeathBehaviour>();
            entity.AddBehaviour<EnemyLookAtBehaviour>();
            
            //Events:
            entity.AddTakeDamageEvent(new BaseEvent<int>());
            entity.AddDeathEvent(new BaseEvent());
        }
    }
}