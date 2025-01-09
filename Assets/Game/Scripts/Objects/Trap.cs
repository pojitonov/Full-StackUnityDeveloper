using UnityEngine;

namespace Game.Scripts
{
    public sealed class Trap : MonoBehaviour, IInteractable, IDestroyable
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private TossMechanic _tossMechanic;

        private void Awake()
        {
            _tossMechanic = new TossMechanic(_rigidbody);
        }
        
        public void Push(Vector2 direction, float force)
        {
            _tossMechanic.Invoke(direction, force);
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}