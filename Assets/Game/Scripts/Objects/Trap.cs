using UnityEngine;

namespace Game.Scripts
{
    public sealed class Trap : MonoBehaviour, ITossable
    {
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Toss(float strength)
        {
            _rigidbody.AddForce(Vector3.up * strength);
        }
    }
}