using System;
using UnityEngine;

namespace Modules.Gameplay
{
    public sealed class TriggerEventReceiver : MonoBehaviour
    {
        public event Action<Collider> OnEntered;
        public event Action<Collider> OnExited;

        private void OnTriggerEnter(Collider other)
        {
            OnEntered?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnExited?.Invoke(other);
        }
    }
}