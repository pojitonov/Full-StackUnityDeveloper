using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    // TODO: Змея при дамаге толкает вверх

    public class PushOnDamageComponent : MonoBehaviour
    {
        [SerializeField] private float _forceStrength = 5f;

        private HealthComponent _healthComponent;
        private LookAtComponent _lookAtComponent;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _healthComponent = GetComponent<HealthComponent>();
            _lookAtComponent = GetComponent<LookAtComponent>();
            
            _healthComponent.OnDamaged += Push;
        }

        private void OnDestroy()
        {
            _healthComponent.OnDamaged -= Push;
        }

        private void Push()
        {
            Vector2 pushDirection = (Vector3)_lookAtComponent.Direction - transform.position;
            GamePhysics.AddForce(_rigidbody, pushDirection, _forceStrength);
        }
    }
}