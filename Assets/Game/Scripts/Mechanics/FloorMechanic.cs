using UnityEngine;

namespace Game.Scripts
{
    public class FloorMechanic
    {
        private static readonly int GROUND_MASK = LayerMask.GetMask("Ground");

        private readonly Transform _player;
        private readonly float _distance;
        public bool CanJump { get; private set; }

        public FloorMechanic(Transform player, bool canJump, float distance)
        {
            _player = player;
            CanJump = canJump;
            _distance = distance;
        }

        public void FixedUpdate()
        {
            CanJump = Physics2D.Raycast(_player.position, Vector2.down, _distance, GROUND_MASK);
        }
    }
}