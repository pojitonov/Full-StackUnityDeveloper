using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private JumpComponent _jumpComponent;
        [SerializeField] private PushObjectsComponent _pushObjectsComponent;
        [SerializeField] private TossObjectsComponent _tossObjectsComponent;
        [SerializeField] private GroundComponent _groundComponent;
        [SerializeField] private LookAtComponent _lookAtComponent;
        [SerializeField] private HealthComponent _healthComponent;

        private void Awake()
        {
            _moveComponent.AddCondition(() => _healthComponent.IsAlive);
            _pushObjectsComponent.AddCondition(() => _healthComponent.IsAlive);
            _tossObjectsComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded);
            _jumpComponent.AddCondition(() => _healthComponent.IsAlive && _groundComponent.IsGrounded);
        }
    }
}