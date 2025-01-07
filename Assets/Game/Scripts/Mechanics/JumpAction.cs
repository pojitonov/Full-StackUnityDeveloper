using UnityEngine;

namespace Game.Scripts
{
    public class JumpAction
    {
        private readonly bool _enabled;
        private readonly Rigidbody2D _rigidbody;
        private readonly float _force;

        public JumpAction(Rigidbody2D rigidbody, float force, bool enabled)
        {
            _rigidbody = rigidbody;
            _force = force;
            _enabled = enabled;
        }

        public void Invoke()
        {
            if (!_enabled)
            {
                return;
            }

            _rigidbody.AddForce(new Vector2(0, _force), ForceMode2D.Impulse);
        }
    }
}