using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DamagePushComponent : MonoBehaviour
    {
        [SerializeField] private PushType _pushType;
        [SerializeField] private float _forceStrength = 5f;

        private Vector2 _direction;
        
        public void ApplyPush(GameObject other)
        {
            if (_pushType == PushType.Horizontal)
                _direction = -(transform.position - other.transform.position);
            else if (_pushType == PushType.Vertical) 
                _direction = Vector2.up;

            AddForceToInteractable(other.gameObject, _direction, _forceStrength);
        }
        
        private void AddForceToInteractable(GameObject item, Vector2 direction, float force)
        {
            if (!item) return;
            if (item.TryGetComponent(out Rigidbody2D rigidbody))
                rigidbody.AddForce(direction.normalized * force);
        }
    }

    internal enum PushType
    {
        Horizontal,
        Vertical
    }
}