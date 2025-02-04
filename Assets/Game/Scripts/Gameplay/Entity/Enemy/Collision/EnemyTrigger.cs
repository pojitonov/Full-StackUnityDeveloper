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
            foreach (var enemy in _enemies)
            {
            }
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (var enemy in _enemies)
            {
            }
        }
    }
}