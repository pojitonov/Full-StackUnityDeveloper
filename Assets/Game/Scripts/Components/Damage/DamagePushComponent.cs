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

            GamePhysics.AddForceToInteractable(other.gameObject, _direction, _forceStrength);
        }
    }

    internal enum PushType
    {
        Horizontal,
        Vertical
    }
}