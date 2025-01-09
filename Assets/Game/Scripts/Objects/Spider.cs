using UnityEngine;

namespace Game.Scripts
{
    public sealed class Spider : MonoBehaviour, IInteractable, IDestroyable
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Transform _transform;
        
        [SerializeField]
        public MoveComponent _moveComponent;

        private TossMechanic _tossMechanic;
        private bool _isAlive = true;

        private void Awake()
        {
            _moveComponent.AddCondition(() => _isAlive);
            _tossMechanic = new TossMechanic(_rigidbody);
        }
        
        public void Push(Vector2 direction, float force)
        {
            _tossMechanic.Invoke(direction, force);
        }

        public void Destroy()
        {
            _isAlive = false;
            gameObject.SetActive(false);
        }
    }
}