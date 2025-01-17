using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class StandingComponent : MonoBehaviour
    {
        [SerializeField] private GroundComponent _groundComponent;

        private Transform _worldTransform;

        public void FixedUpdate()
        {
            var groundTransform = _groundComponent.Transform;

            transform.SetParent(_groundComponent.IsGrounded ? groundTransform : _worldTransform);
        }
    }
}