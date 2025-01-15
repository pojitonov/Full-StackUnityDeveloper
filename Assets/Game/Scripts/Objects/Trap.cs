using UnityEngine;

namespace Game.Scripts
{
    // TODO: Переделать логику как подкидываем без IInteractable и Push в каждом компоненте
    public sealed class Trap : MonoBehaviour, IInteractable
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        
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