using UnityEngine;

namespace Game.Scripts
{
    public class PatrolComponent : MonoBehaviour
    {
        [SerializeField]
        private MoveComponent _moveComponent;

        [SerializeField]
        private float _stoppingThreshold = 0.5f;

        [SerializeField]
        private Transform _waypoint1;

        [SerializeField]
        private Transform _waypoint2;

        private Transform _currentTarget;

        private void Start()
        {
            _currentTarget = _waypoint1;
        }

        private void FixedUpdate()
        {
            if (Vector2.Distance(_moveComponent.GetTransform(), _currentTarget.position) < _stoppingThreshold)
                _currentTarget = _currentTarget == _waypoint1 ? _waypoint2 : _waypoint1;

            var direction = _currentTarget.position - _moveComponent.GetTransform();
            _moveComponent.Move(direction);
        }
    }
}