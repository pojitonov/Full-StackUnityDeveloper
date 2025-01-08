using UnityEngine;

namespace Game.Scripts
{
    [RequireComponent(typeof(MoveComponent), typeof(PatrolComponent))]
    public sealed class Spider : MonoBehaviour, IDestroyable
    {
        [SerializeField]
        public MoveComponent _moveComponent;

        [SerializeField]
        public PatrolComponent _patrolComponent;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Transform _transform;
        
        private bool _isAlive = true;

        private void Awake()
        {
            _moveComponent.Initialize(_rigidbody, _transform);
            _moveComponent.AddCondition(() => _isAlive);
        }

        public void Destroy()
        {
            _isAlive = false;
            gameObject.SetActive(false);
        }
    }
}