using System;
using UnityEngine;

namespace Game.Scripts
{
    public class PushComponent : MonoBehaviour
    {
        public event Action<Vector2> OnStateChanged;

        [SerializeField]
        private float _forceStrength;

        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void Push(Vector2 pushDirection)
        {
            OnStateChanged?.Invoke(pushDirection);
            
            foreach (var interactable in _character._lookAtComponent.GetInteractableInFront())
            {
                interactable.Push(pushDirection, _forceStrength);
            }
        }
    }
}