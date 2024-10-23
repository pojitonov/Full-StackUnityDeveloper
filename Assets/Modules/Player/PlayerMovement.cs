using UnityEngine;

namespace ShootEmUp
{
    public class PlayerMovement : IPlayerMovement
    {
        private readonly Player character;

        public PlayerMovement(Player character)
        {
            this.character = character;
        }

        public void Move(float direction)
        {
            Vector2 moveDirection = new Vector2(direction, 0);
            Vector2 moveStep = moveDirection * (Time.fixedDeltaTime * character.speed);
            Vector2 targetPosition = character._rigidbody.position + moveStep;
            character._rigidbody.MovePosition(targetPosition);
        }
    }
}