using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class StandingComponent : MonoBehaviour
    {
        private GroundComponent _groundComponent;
        private GamePhysics _physics;

        private void Awake()
        {
            _groundComponent = GetComponent<GroundComponent>();
        }

        private Transform _worldTransform;

        public void FixedUpdate()
        {
            var groundTransform = _groundComponent.GroundTransform;

            transform.SetParent(_groundComponent.IsGrounded ? groundTransform : _worldTransform);
        }
    }
}