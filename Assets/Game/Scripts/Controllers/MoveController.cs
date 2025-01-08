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
            float moveDirection = 0;

            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1;
            }

            _character._moveComponent.Move(moveDirection);
        }
    }
}