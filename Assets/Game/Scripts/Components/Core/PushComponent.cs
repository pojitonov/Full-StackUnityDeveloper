
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
            var direction = _character.GetComponent<LookAtComponent>().LookAtDirection;

            OnStateChanged?.Invoke();
            
            foreach (var interactable in _character.GetComponent<LookAtComponent>().GetInteractableInFront())
            {
                interactable.Push(direction, _forceStrength);
            }
        }
    }
}