using UnityEngine;

namespace Game.Gameplay
{
    public static class InputUseCase
    {
        public static Vector3 GetMoveDirection()
        {
            if (Input.GetKey(KeyCode.W))
                return Vector3.forward;

            if (Input.GetKey(KeyCode.S))
                return Vector3.back;

            if (Input.GetKey(KeyCode.A))
                return Vector3.left;

            if (Input.GetKey(KeyCode.D))
                return Vector3.right;
            
            return Vector3.zero;
        }
    }
}