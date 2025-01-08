using UnityEngine;

namespace Game.Scripts
{
    [RequireComponent(typeof(MoveComponent))]
    public class PatrolComponent : MonoBehaviour
    {
        [SerializeField]
        private MoveComponent _moveComponent;
        
        [SerializeField]
        private float _stoppingThreshold = 0.5f;
        
        [SerializeField]
        private Transform[] _waypoints;
        
        private int _pointIndex;

        public void Update()
        {
            if (Vector2.Distance(_moveComponent._transform.position, _waypoints[_pointIndex].position) < _stoppingThreshold)
            {
                _pointIndex++;
                if (_pointIndex >= _waypoints.Length)
                {
                    _pointIndex = 0;
                }
            }

            var direction = _waypoints[_pointIndex].position - _moveComponent._transform.position;
            _moveComponent.Move(direction);
        }
    }
}