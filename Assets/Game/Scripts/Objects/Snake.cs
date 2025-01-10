using UnityEngine;

namespace Game.Scripts
{
    public sealed class Snake : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;
        
        private PushMechanic _pushMechanic;

        private void Awake()
        {
            _pushMechanic = new PushMechanic(_rigidbody);
        }
        
        public void Push(Vector2 direction, float force)
        {
            _pushMechanic.Invoke(direction, force);
        }
    }
}