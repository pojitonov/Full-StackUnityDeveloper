using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushComponent : MonoBehaviour
    {
        public event Action OnPushed;
        public event Action OnTossed;

        [SerializeField] private float _forceStrength;

        private LookAtComponent _lookAtComponent;
        private GamePhysics _gamePhysics;

        private void Awake()
        {
            _lookAtComponent = GetComponent<LookAtComponent>();
        }

        public void Push()
        {
            AddForceToInteractable(_lookAtComponent.Direction);
            OnPushed?.Invoke();
        }

        public void Toss()
        {
            AddForceToInteractable(Vector2.up);
            OnTossed?.Invoke();
        }

        private void AddForceToInteractable(Vector2 direction)
        {
            foreach (var interactable in _lookAtComponent.GetInteractables())
            {
                interactable.TryGetComponent(out Rigidbody2D rigidbody);
                GamePhysics.AddForce(rigidbody, direction, _forceStrength);
            }
        }
    }
}