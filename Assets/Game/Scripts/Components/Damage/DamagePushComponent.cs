using UnityEngine;

namespace Game.Scripts.Components
{
    public class DamagePushComponent : MonoBehaviour
    {
        private const float FORCE_MULTIPLIER = 100;

        [SerializeField] private DamagePushType _pushType;
        [SerializeField] private float _forceStrength = 5f;

        private Vector2 forceDirection;

        public void ApplyPush(GameObject other)
        {
            if (_pushType == DamagePushType.Horizontal)
                forceDirection = -(transform.position - other.transform.position);
            else if (_pushType == DamagePushType.Vertical)
                forceDirection = Vector2.up;

            if (!other) return;
            if (other.TryGetComponent(out Rigidbody2D rigidbody))
                rigidbody.AddForce(forceDirection.normalized * (_forceStrength * FORCE_MULTIPLIER));
        }
    }
}