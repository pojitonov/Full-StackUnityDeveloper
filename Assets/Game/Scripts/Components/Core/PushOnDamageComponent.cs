using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushOnDamageComponent : MonoBehaviour
    {
        [SerializeField] private PushType _pushType;
        [SerializeField] private float _forceStrength = 5f;
        [SerializeField] private DamageComponent _damageComponent;

        private Vector2 _direction;

        private void OnEnable()
        {
            _damageComponent.OnDamaged += ApplyPush;
        }
        
        private void OnDisable()
        {
            _damageComponent.OnDamaged -= ApplyPush;
        }

        private void ApplyPush(GameObject other)
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