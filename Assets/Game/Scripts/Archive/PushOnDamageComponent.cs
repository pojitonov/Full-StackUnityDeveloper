using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushOnDamageComponent : MonoBehaviour
    {
        [SerializeField] private PushType _pushType;
        [SerializeField] private float _forceStrength = 5f;
        private Vector2 _pushDirection;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Rigidbody2D>(out var rigidbody))
            {
                if (_pushType == PushType.Horizontal)
                {
                    _pushDirection = -(transform.position - other.transform.position).normalized;
                }
                else if (_pushType == PushType.Vertical)
                {
                    _pushDirection = Vector2.up;
                }

                GamePhysics.AddForce(rigidbody, _pushDirection, _forceStrength);
            }
        }
    }

    internal enum PushType
    {
        Horizontal,
        Vertical
    }
}