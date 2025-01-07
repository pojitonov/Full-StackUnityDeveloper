using UnityEngine;

namespace Game.Scripts
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private Character character;

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

            character._moveDirection = moveDirection;
        }
    }
}