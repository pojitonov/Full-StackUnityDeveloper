using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class PatrolMechanic
    {
        public float MoveDirection { get; private set; }
        
        private readonly IEnumerator<Vector3> _patrolPoints;
        private readonly Transform _transform;
        private readonly float stoppingDistance = 0.5f;

        public PatrolMechanic(IEnumerator<Vector3> patrolPoints, Transform transform)
        {
            _patrolPoints = patrolPoints;
            _transform = transform;
        }

        public void Start()
        {
            _patrolPoints.MoveNext();
        }

        public void FixedUpdate()
        {
            Vector3 currentPosition = _transform.position;
            Vector3 targetPosition = _patrolPoints.Current;
            Vector3 distance = targetPosition - currentPosition;

            if (distance.magnitude <= stoppingDistance)
            {
                _patrolPoints.MoveNext();
            }
            else
            {
                MoveDirection = distance.normalized.x;
            }
        }
    }
}