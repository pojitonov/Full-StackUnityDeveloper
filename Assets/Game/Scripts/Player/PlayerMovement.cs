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
            Vector2 moveStep = moveDirection * (Time.fixedDeltaTime * character.Speed);
            Vector2 targetPosition = character.Rigidbody2D.position + moveStep;
            character.Rigidbody2D.MovePosition(targetPosition);
        }
    }
}