using UnityEngine;

namespace Game
{
    public sealed class Platform : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private PatrolComponent _patrolComponent;

        private void Awake()
        {
            _patrolComponent.SetMoveable(_moveComponent);
        }
    }
}