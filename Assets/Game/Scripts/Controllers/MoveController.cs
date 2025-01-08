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
            float direction = 0;

            if (Input.GetKey(KeyCode.A))
            {
                direction = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = 1;
            }

            _character._moveComponent.Move(direction);
        }
    }
}