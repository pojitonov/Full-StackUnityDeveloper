using UnityEngine;

namespace Game
{
    public class PatrolComponent : MonoBehaviour
    {
        [SerializeField] private float _stoppingThreshold = 0.5f;
        [SerializeField] private Transform _waypoint1;
        [SerializeField] private Transform _waypoint2;

        private Transform _target;
        private IMoveable _moveable;

        private void Start()
        {
            _target = _waypoint1;
        }

        private void FixedUpdate()
        {
            if (Vector2.Distance(_moveable.Position, _target.position) < _stoppingThreshold)
                _target = _target == _waypoint1 ? _waypoint2 : _waypoint1;
            
            _moveable.Direction = _target.position - _moveable.Position;
        }

        public void SetMoveable(IMoveable moveable)
        {
            _moveable = moveable;
        }
    }
}