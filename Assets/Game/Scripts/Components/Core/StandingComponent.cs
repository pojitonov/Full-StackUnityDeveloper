using UnityEngine;

namespace Game.Scripts.Components
{
    public class StandingComponent : MonoBehaviour
    {
        private GroundComponent _groundComponent;

        private void Awake()
        {
            _groundComponent = GetComponent<GroundComponent>();
        }

        private Transform _worldTransform;

        public void FixedUpdate()
        {
            var groundTransform = _groundComponent.RaycastTransform;

            transform.SetParent(_groundComponent.CheckGround() ? groundTransform : _worldTransform);
        }
    }
}