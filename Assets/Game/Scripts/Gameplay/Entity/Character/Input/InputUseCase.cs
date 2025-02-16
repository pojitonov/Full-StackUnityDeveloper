using Modules.Common;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public static class InputUseCase
    {
        public static Vector3 GetDirection(Joystick joystick)
        {
            var direction = Vector3.zero;
            
            if (joystick && joystick.IsPressed)
            {
                direction += new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            }

            return direction.normalized;
        }
    }
}