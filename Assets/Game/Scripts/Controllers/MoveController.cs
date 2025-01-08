using UnityEngine;

namespace Game.Scripts
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        private MoveComponent _moveComponent;

        private void Update()
        {
            Vector2 direction = Vector2.zero;

            if (Input.GetKey(KeyCode.A))
            {
                direction = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = Vector2.right;
            }

            _character._moveComponent.Move(direction);
        }
    }
}