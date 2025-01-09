using UnityEngine;

namespace Game.Scripts
{
    public sealed class Spider : MonoBehaviour, IDestroyable
    {
        [SerializeField]
        public MoveComponent _moveComponent;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Transform _transform;
        
        private bool _isAlive = true;

        private void Awake()
        {
            _moveComponent.AddCondition(() => _isAlive);
        }

        public void Destroy()
        {
            _isAlive = false;
            gameObject.SetActive(false);
        }
    }
}