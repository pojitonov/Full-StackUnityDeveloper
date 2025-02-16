using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public static class InputUseCase
    {
        public static Vector3 GetMoveDirection(GameContext context)
        {
            var direction = Vector3.zero;
            var moveJoystick = context.GetMoveJoystick();

            if (moveJoystick && moveJoystick.IsPressed)
            {
                direction += new Vector3(moveJoystick.Horizontal, 0, moveJoystick.Vertical);
            }

            return direction.normalized;
        }

        public static void Attack(GameContext context, float deltaTime, Cooldown cooldown)
        {
            var attackJoystick = context.GetAttackJoystick();
            if (!attackJoystick || !attackJoystick.IsPressed)
                return;

            var direction = new Vector3(attackJoystick.Horizontal, 0, attackJoystick.Vertical).normalized;
            
            var character = context.GetCharacter();
            var isAttacking = context.GetIsAttacking();

            if (direction.sqrMagnitude > 0.01f)
            {
                character.RotateTowards(direction, deltaTime);

                if (!isAttacking.Value)
                {
                    isAttacking.Value = true;
                    cooldown.Reset();
                }

                if (cooldown.IsExpired())
                {
                    character.GetAttackAction().Invoke();
                    cooldown.Reset();
                    isAttacking.Value = false;
                }
                else
                {
                    cooldown.Tick(deltaTime);
                }
            }
        }
    }
}