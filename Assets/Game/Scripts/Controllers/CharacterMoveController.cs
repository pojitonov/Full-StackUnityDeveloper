using UnityEngine;

namespace Game.Scripts
{
    public sealed class CharacterMoveController : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

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

            _character._moveDirection = moveDirection;
        }
    }
}