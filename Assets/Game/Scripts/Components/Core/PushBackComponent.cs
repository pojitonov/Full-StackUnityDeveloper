using UnityEngine;

namespace Game.Scripts.Components.Core
{
    public class PushBackComponent : MonoBehaviour
    {
        [SerializeField] private float _pushBackForce = 5f;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private LookAtComponent _lookAtComponent;
        
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _healthComponent.OnDamaged += PushBack;
        }

        private void OnDestroy()
        {
            _healthComponent.OnDamaged -= PushBack;
        }
        
        private void PushBack()
        {
            Vector2 pushDirection = (Vector3)_lookAtComponent.LookAtDirection - transform.position;
            var pushMechanic = new PushMechanic(_rigidbody);
            pushMechanic.Invoke(pushDirection, _pushBackForce);
        }
    }
}