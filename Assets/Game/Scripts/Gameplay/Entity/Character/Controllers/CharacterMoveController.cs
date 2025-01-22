using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class CharacterMoveController : MonoBehaviour
    {
        [SerializeField]
        private SceneEntity _character;

        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.UpArrow)) 
                Move(Vector3.forward);

            if (Input.GetKey(KeyCode.DownArrow)) 
                Move(Vector3.back);

            if (Input.GetKey(KeyCode.LeftArrow)) 
                Move(Vector3.left);

            if (Input.GetKey(KeyCode.RightArrow)) 
                Move(Vector3.right);
        }

        private void Move(Vector3 direction)
        {
            float deltaTime = Time.deltaTime;
            _character.MoveTowards(direction, deltaTime);
            _character.RotateTowards(direction, deltaTime);
        }
    }
}