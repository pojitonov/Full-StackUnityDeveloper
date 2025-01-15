using Game.Scripts;
using UnityEngine;

namespace Components.Core
{
    public class FollowerComponent : MonoBehaviour
    {
        [SerializeField]
        private GroundComponent _groundComponent;

        private Transform _worldTransform;

        public void FixedUpdate()
        {
            var groundTransform = _groundComponent.RaycastTransform;

            transform.SetParent(_groundComponent.CheckGround() ? groundTransform : _worldTransform);
        }
    }
}