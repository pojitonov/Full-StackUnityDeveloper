using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public sealed class EnemyTrigger : MonoBehaviour
    {
        [SerializeField] private SceneEntity[] _enemies;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity target) || !target.HasCharacterTag()) 
                return;
            
            foreach (var enemy in _enemies)
            {
                enemy.SetTarget(target);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (var enemy in _enemies)
            {
                enemy.SetTarget(null);
            }
        }
    }
}