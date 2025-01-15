using UnityEngine;

namespace Game.Scripts.Common
{
    public class GamePhysics
    {
        private const float _multiplier = 100;

        public static void AddForce(Rigidbody2D rigidbody, Vector2 direction, float force)
        {
            rigidbody.AddForce(direction.normalized * (force * _multiplier));
        }
    }
}