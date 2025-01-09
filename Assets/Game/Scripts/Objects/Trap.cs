using UnityEngine;

namespace Game.Scripts
{
    public sealed class Trap : MonoBehaviour, ITossable
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private TossMechanic _tossMechanic;

        private void Awake()
        {
            _tossMechanic = new TossMechanic(_rigidbody);
        }

        public void Toss(Vector2 direction, float force)
        {
            _tossMechanic.Invoke(direction, force);
        }
    }
}