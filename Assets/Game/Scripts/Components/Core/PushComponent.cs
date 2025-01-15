using System;
using UnityEngine;

namespace Game.Scripts
{
    public class PushComponent : MonoBehaviour, ITriggerable
    {
        public event Action OnStateChanged;

        [SerializeField] private float _forceStrength;

        private LookAtComponent _lookAtComponent;

        private void Awake()
        {
            _lookAtComponent = GetComponent<LookAtComponent>();
        }

        public void Push(Vector2 direction)
        {
            foreach (var interactable in _lookAtComponent.GetInteractableInFront())
            {
                interactable.Push(direction, _forceStrength);
            }

            OnStateChanged?.Invoke();
        }
    }
}