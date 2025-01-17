using Game.Scripts.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Objects
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private FlipComponent _flipComponent;
        [SerializeField] private JumpComponent _jumpComponent;
        [FormerlySerializedAs("_pushObjectsComponent")]
        [SerializeField] private PushComponent pushComponent;
        [FormerlySerializedAs("_tossObjectsComponent")]
        [SerializeField] private TossComponent tossComponent;
        [SerializeField] private GroundComponent _groundComponent;
        [SerializeField] private LookAtComponent _lookAtComponent;
        [SerializeField] private HealthComponent _healthComponent;

        private void Awake()
        {
            _moveComponent.AddCondition(() => _healthComponent.IsAlive);
            pushComponent.AddCondition(() => _healthComponent.IsAlive);
            tossComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded);
            _jumpComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded);
        }
        
        private void Update()
        {
            _flipComponent.Direction = _moveComponent.Direction;
            _lookAtComponent.SetDirection(_moveComponent.Direction);
        }
    }
}