using System;
using UnityEngine;

namespace Game.Scripts
{
    public class GroundComponent : MonoBehaviour
    {
        public event Action<bool> OnStateChanged;

        [SerializeField]
        private float _detectDistance = 0.1f;

        [SerializeField]
        private Transform _feetTransform;

        [SerializeField]
        private LayerMask _mask;

        private bool _isGrounded;

        private void Update()
        {
            var newState = CheckGround();
            if (newState == _isGrounded) return;
            _isGrounded = newState;
            OnStateChanged?.Invoke(_isGrounded);
        }

        private bool CheckGround()
        {
            return Physics2D.Raycast(_feetTransform.position, Vector2.down, _detectDistance, _mask);
        }
    }
}