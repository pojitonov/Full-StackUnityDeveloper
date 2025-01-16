using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class StandingComponent : MonoBehaviour
    {
        private GroundComponent _groundComponent;
        private Transform _worldTransform;

        private void Awake()
        {
            _groundComponent = GetComponent<GroundComponent>();
        }
        
        public void FixedUpdate()
        {
            var groundTransform = _groundComponent.Transform;

            transform.SetParent(_groundComponent.IsGrounded ? groundTransform : _worldTransform);
        }
    }
}