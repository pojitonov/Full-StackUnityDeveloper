using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts
{
    public sealed class Spider : MonoBehaviour, IDestroyable
    {
        public MoveComponent _moveComponent;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Transform _spiderTransform;
        
        [SerializeField]
        private Transform[] _waypoints;
        
        private PatrolMechanic _patrolMechanic;
        private bool _isAlive = true;

        private void Awake()
        {
            _moveComponent.Initialize(_rigidbody);
            _moveComponent.AddCondition(() => _isAlive);
            _patrolMechanic = new PatrolMechanic(_waypoints);
        }

        private void FixedUpdate()
        {
            _moveComponent.Move(_patrolMechanic.Invoke(_spiderTransform));
        }

        public void Destroy()
        {
            _isAlive = false;
            gameObject.SetActive(false);
        }
    }
}