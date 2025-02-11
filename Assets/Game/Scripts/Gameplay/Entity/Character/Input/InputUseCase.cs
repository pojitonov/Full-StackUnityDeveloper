using Atomic.Entities;
using Modules.Common;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public static class InputUseCase
    {
        private static Joystick _moveJoystick;
        private static Joystick _attackJoystick;
        private static bool _isFiring;

        public static void SetMoveJoystick(Joystick joystick)
        {
            _moveJoystick = joystick;
        }

        public static void SetAttackJoystick(Joystick joystick)
        {
            _attackJoystick = joystick;
        }

        public static Vector3 GetMoveDirection()
        {
            var direction = Vector3.zero;

            if (_moveJoystick && _moveJoystick.IsPressed)
            {
                direction += new Vector3(_moveJoystick.Horizontal, 0, _moveJoystick.Vertical);
            }

            return direction.normalized;
        }

        public static void Attack(SceneEntity character, Cooldown cooldown)
        {
            if (!_attackJoystick || !_attackJoystick.IsPressed) 
                return;
            
            var direction = new Vector3(_attackJoystick.Horizontal, 0, _attackJoystick.Vertical).normalized;

            if (direction.sqrMagnitude > 0.01f)
            {
                character.RotateTowards(direction, Time.deltaTime);

                if (!_isFiring)
                {
                    _isFiring = true;
                    cooldown.Reset();
                }

                if (cooldown.IsExpired())
                {
                    character.GetAttackAction().Invoke();
                    cooldown.Reset();
                    _isFiring = false;
                }
                else
                {
                    cooldown.Tick(Time.deltaTime);
                }
            }
        }
    }
}