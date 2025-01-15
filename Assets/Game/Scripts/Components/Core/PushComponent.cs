using System;
using UnityEngine;

namespace Game.Scripts
{
    // TODO: Перепелить LookAtComponent метод Push выглядит странно
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
            ApplyForce(_lookAtComponent.LookAtDirection);
            OnPushed?.Invoke();
        }

        public void Toss()
        {
            ApplyForce(Vector2.up);
            OnTossed?.Invoke();
        }

        private void ApplyForce(Vector2 direction)
        {
            foreach (var interactable in _lookAtComponent.GetInteractableInFront())
            {
                interactable.Push(direction, _forceStrength);
            }
        }
    }
}