using System;
using UnityEngine;

namespace Game.Scripts
{
    public class GroundComponent : MonoBehaviour
    {
        public event Action<bool> OnGroundStateChanged;

        [SerializeField]
        private float _detectDistance = 0.1f;

        [SerializeField]
        private Transform _feetTransform;

        [SerializeField]
        private LayerMask _mask;

        private bool _isGrounded;

        private void Update()
        {
            var newGroundState = CheckGround();
            if (newGroundState == _isGrounded) return;
            _isGrounded = newGroundState;
            OnGroundStateChanged?.Invoke(_isGrounded);
        }

        public bool CheckGround()
        {
            return Physics2D.Raycast(_feetTransform.position, Vector2.down, _detectDistance, _mask);
        }
    }
}