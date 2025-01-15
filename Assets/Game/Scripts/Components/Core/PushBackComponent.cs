using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushBackComponent : MonoBehaviour
    {
        [SerializeField] private float _forceStrength = 5f;

        private HealthComponent _healthComponent;
        private LookAtComponent _lookAtComponent;

        private Rigidbody2D _rigidbody;
        private GamePhysics _gamePhysics;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _healthComponent = GetComponent<HealthComponent>();
            _lookAtComponent = GetComponent<LookAtComponent>();
            
            _healthComponent.OnDamaged += PushBack;
        }

        private void OnDestroy()
        {
            _healthComponent.OnDamaged -= PushBack;
        }

        private void PushBack()
        {
            Vector2 pushDirection = (Vector3)_lookAtComponent.Direction - transform.position;
            GamePhysics.AddForce(_rigidbody, pushDirection, _forceStrength);
        }
    }
}