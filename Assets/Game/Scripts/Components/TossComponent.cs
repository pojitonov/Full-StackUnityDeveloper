using System;
using UnityEngine;

namespace Game.Scripts
{
    public class TossComponent : MonoBehaviour, ITriggerable
    {
        public event Action OnStateChanged;

        [SerializeField]
        private float _forceStrength;

        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void Toss()
        {
            OnStateChanged?.Invoke();
            
            foreach (var interactable in _character._lookAtComponent.GetInteractableInFront())
            {
                interactable.Push(Vector2.up, _forceStrength);
            }
        }
    }
}