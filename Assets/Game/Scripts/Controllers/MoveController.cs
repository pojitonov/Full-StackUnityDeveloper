using UnityEngine;

namespace Game
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField] private Character _character;

        private void Update()
        {
            var direction = Vector2.zero;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                direction = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                direction = Vector2.right;
            }

            _character.Move(direction);
        }
    }
}