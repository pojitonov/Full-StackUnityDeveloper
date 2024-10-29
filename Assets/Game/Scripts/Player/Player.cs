using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Player : Character
    {
        public Action<Player, int> OnHealthChanged;
        public Action<Player> OnHealthEmpty;
        private bool isFiring;
        private int moveDirection;
        
        private void FixedUpdate()
        {
            Move(moveDirection);

            if (isFiring)
            {
                Attack();
                isFiring = false;
            }
        }

        public void SetMoveDirection(int direction)
        {
            moveDirection = direction;
        }

        public void SetFiring(bool firing)
        {
            isFiring = firing;
        }
        
        private void Move(float direction)
        {
            Vector2 moveDirection = new Vector2(direction, 0);
            Vector2 moveStep = moveDirection * (Time.fixedDeltaTime * speed);
            Vector2 targetPosition = rigidbody2D.position + moveStep;
            rigidbody2D.MovePosition(targetPosition);
        }

        private void Attack()
        {
            Vector2 startPosition = firePoint.position;
            Vector2 direction = firePoint.rotation * Vector3.up;
            
            SpawnBullet(startPosition, direction * 3, Color.blue, (int)PhysicsLayer.PLAYER_BULLET);
        }
    }
}