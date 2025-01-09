using UnityEngine;

namespace Game.Scripts
{
    public class GroundComponent : MonoBehaviour
    {
        [SerializeField]
        private float _detectDistance = 0.1f;

        [SerializeField]
        private Transform _feetTransform;

        [SerializeField]
        private LayerMask _mask;

        public bool CheckGround()
        {
            return Physics2D.Raycast(_feetTransform.position, Vector2.down, _detectDistance, _mask);
        }
    }
}