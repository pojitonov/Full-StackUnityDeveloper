using System;
using UnityEngine;

namespace Game.Scripts
{
    // TODO: Змея при дамаге толкает вверх

    public class PushComponent : MonoBehaviour
    {
        public event Action OnPushed;
        public event Action OnTossed;

        [SerializeField] private float _forceStrength;

        private LookAtComponent _lookAtComponent;

        private void Awake()
        {
            _lookAtComponent = GetComponent<LookAtComponent>();
        }

        public void Push()
        {
            ApplyForceToInteractable(_lookAtComponent.LookAtDirection);
            OnPushed?.Invoke();
        }

        public void Toss()
        {
            ApplyForceToInteractable(Vector2.up);
            OnTossed?.Invoke();
        }

        private void ApplyForceToInteractable(Vector2 direction)
        {
            foreach (var interactable in _lookAtComponent.GetInteractables())
            {
                interactable.TryGetComponent(out Rigidbody2D rigidbody);
                rigidbody.AddForce(direction.normalized * (_forceStrength * 100));
            }
        }
    }
}