using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public class ShipMovementComponent
    {
        [SerializeField]
        private float speed = 5.0f;
        
        private readonly Rigidbody2D rigidbody2D;
        private int moveDirection;

        public ShipMovementComponent(Rigidbody2D rigidbody2D)
        {
            this.rigidbody2D = rigidbody2D;
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