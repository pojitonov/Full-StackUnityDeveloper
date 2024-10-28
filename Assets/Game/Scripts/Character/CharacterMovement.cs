using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMovement : IMovable
    {
        private readonly Character character;

        public CharacterMovement(Character character)
        {
            this.character = character;
        }

        public void Move()
        {
            Vector2 vector = character.Destination - (Vector2)character.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                character.IsPointReached = true;
                return;
            }

            Vector2 direction = vector.normalized * Time.fixedDeltaTime;
            Vector2 nextPosition = character.Rigidbody2D.position + direction * character.Speed;
            character.Rigidbody2D.MovePosition(nextPosition);
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