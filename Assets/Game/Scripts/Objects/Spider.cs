using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public sealed class Spider : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private float _moveDirection;

        [SerializeField]
        private float _moveSpeed = 5f;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Transform _waypoint1;

        [SerializeField]
        private Transform _waypoint2;

        private MovementMechanic _movementMechanic;
        private KillCharacterMechanic _killMechanic;
        private PatrolMechanic _patrolMechanic;

        private void Awake()
        {
            _movementMechanic = new MovementMechanic(_rigidbody, _moveSpeed);
            _killMechanic = new KillCharacterMechanic();
            _patrolMechanic = new PatrolMechanic(GetPatrolPoints(), transform);
        }

        private void Start()
        {
            _patrolMechanic.Start();
        }

        private void FixedUpdate()
        {
            _moveDirection = _patrolMechanic.MoveDirection;
            _movementMechanic.FixedUpdate(_moveDirection);
            _patrolMechanic.FixedUpdate();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            _killMechanic.OnTriggerEnter2D(other);
        }

        private IEnumerator<Vector3> GetPatrolPoints()
        {
            while (true)
            {
                yield return _waypoint1.position;
                yield return _waypoint2.position;
            }
        }
    }
}