using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(GroundComponent))]
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
            transform.SetParent(_groundComponent.IsGrounded ? _groundComponent.Transform : _worldTransform);
        }
    }
}