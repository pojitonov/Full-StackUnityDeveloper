using UnityEngine;

namespace Game.Scripts
{
    public class LookAtComponent : MonoBehaviour
    {
        public Vector2 FacingDirection => _facingDirection;
        
        private Vector2 _facingDirection = Vector2.right;
        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void Update()
        {
            UpdateFacingDirection(_character.MoveDirection);
        }

        private void UpdateFacingDirection(Vector2 direction)
        {
            if (direction == Vector2.right || direction == Vector2.left)
            {
                _facingDirection = direction;
            }
        }
    }
}