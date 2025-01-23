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
        
        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddHealth(new ReactiveVariable<int>(_health));
            entity.AddDamageableTag();

            //Behaviours:
            entity.AddBehaviour<DeathBehaviour>();
        }
    }
}