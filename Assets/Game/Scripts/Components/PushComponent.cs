
using System;
using UnityEngine;

namespace Game.Scripts
{
    public class PushComponent : MonoBehaviour, ITriggerable
    {
        public event Action OnStateChanged;

        [SerializeField]
        private float _forceStrength;

        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void Push()
        {
            var direction = _character._lookAtComponent.LookAtDirection;

            OnStateChanged?.Invoke();
            
            foreach (var interactable in _character._lookAtComponent.GetInteractableInFront())
            {
                interactable.Push(direction, _forceStrength);
            }
        }
    }
}