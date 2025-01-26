using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class Platform : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private PatrolComponent _patrolComponent;
        
        private void Awake()
        {
            _patrolComponent.Init(_moveComponent);
        }
    }
}