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
            // if (other.TryGetEntity(out var target) && !target.HasCharacterTag())

            foreach (var enemy in _enemies)
            {
                // enemy.SetTarget(target);
                enemy.GetIsChasing().Value = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (var enemy in _enemies)
            {
                // enemy.DelTarget();
                enemy.GetIsChasing().Value = false;
            }
        }
    }
}