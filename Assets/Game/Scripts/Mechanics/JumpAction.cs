using UnityEngine;

namespace Game.Scripts
{
    public class JumpAction
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _force;

        public JumpAction(Rigidbody2D rigidbody, float force)
        {
            _rigidbody = rigidbody;
            _force = force;
        }

        public void Invoke(bool enabled)
        {
            if (!enabled)
            {
                return;
            }

            _rigidbody.AddForce(new Vector2(0, _force), ForceMode2D.Impulse);
        }
    }
}