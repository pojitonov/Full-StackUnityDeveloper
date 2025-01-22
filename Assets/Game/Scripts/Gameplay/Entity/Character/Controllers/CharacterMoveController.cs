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
            if (Input.GetKey(KeyCode.W)) 
                Move(Vector3.forward);

            if (Input.GetKey(KeyCode.S)) 
                Move(Vector3.back);

            if (Input.GetKey(KeyCode.A)) 
                Move(Vector3.left);

            if (Input.GetKey(KeyCode.D)) 
                Move(Vector3.right);
        }

        private void Move(Vector3 direction)
        {
            float deltaTime = Time.deltaTime;
            _character.GetMoveAction().Invoke(direction, deltaTime);
        }
    }
}