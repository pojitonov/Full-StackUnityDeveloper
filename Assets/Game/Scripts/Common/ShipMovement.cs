using UnityEngine;

namespace ShootEmUp
{
    public class ShipMovement
    {
        private readonly Rigidbody2D rigidbody2D;
        private readonly float speed;
        private int moveDirection;

        public ShipMovement(Rigidbody2D rigidbody2D, float speed)
        {
            this.rigidbody2D = rigidbody2D;
            this.speed = speed;
        }

        public void FixedUpdate()
        {
            Move(moveDirection);
        }

        public void SetDirection(int direction)
        {
            moveDirection = direction;
        }

        private void Move(float direction)
        {
            Vector2 moveDirection = new Vector2(direction, 0);
            Vector2 moveStep = moveDirection * (Time.fixedDeltaTime * speed);
            Vector2 targetPosition = rigidbody2D.position + moveStep;
            rigidbody2D.MovePosition(targetPosition);
        }
    }
}