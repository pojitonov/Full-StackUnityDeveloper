using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public sealed class EnemyTrigger : MonoBehaviour
    {
        [SerializeField]
        private SceneEntity[] _enemies;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IReactiveVariable<IEntity> character)) return;
            foreach (var enemy in _enemies)
            {
                if (enemy.TryGetEntity(out IEntity enemyEntity))
                {
                    enemyEntity.SetTarget(character);
                    Debug.Log($"Target Set for: {enemyEntity}");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IReactiveVariable<IEntity> character)) return;
            foreach (var enemy in _enemies)
            {
                if(enemy.TryGetEntity(out var enemyEntity))
                {
                    enemyEntity.DelTarget();
                    Debug.Log($"Target Del for: {enemyEntity}");
                }
            }
        }
    }
}