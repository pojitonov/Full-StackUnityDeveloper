using UnityEngine;

namespace Game.Scripts
{
    public class PatrolMechanic
    {
        private const float STOPPING_DISTANCE = 0.5f;
        private int _currentPointIndex;
        private readonly Transform[] _waypoints;

        public PatrolMechanic(Transform[] waypoints)
        {
            _waypoints = waypoints;
        }

        public Vector2 Invoke(Transform transform)
        {
            if (Vector2.Distance(transform.position, _waypoints[_currentPointIndex].position) < STOPPING_DISTANCE)
            {
                _currentPointIndex++;
                if (_currentPointIndex >= _waypoints.Length)
                {
                    _currentPointIndex = 0;
                }
            }

            var direction = _waypoints[_currentPointIndex].position - transform.position;
            return direction;
        }
    }
}