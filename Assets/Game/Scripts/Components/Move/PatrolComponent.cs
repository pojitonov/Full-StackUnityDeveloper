using UnityEngine;

namespace Game.Scripts.Components
{
    public class PatrolComponent : MonoBehaviour
    {
        [SerializeField] private float _stoppingThreshold = 0.5f;
        [SerializeField] private Transform _waypoint1;
        [SerializeField] private Transform _waypoint2;
        [SerializeField] private MoveComponent _moveComponent;

        private Transform _target;

        private void Start()
        {
            _target = _waypoint1;
        }

        private void FixedUpdate()
        {
            if (Vector2.Distance(_moveComponent.Transform.position, _target.position) < _stoppingThreshold)
                _target = _target == _waypoint1 ? _waypoint2 : _waypoint1;
            
            _moveComponent.Direction = _target.position - _moveComponent.Transform.position;
        }
    }
}