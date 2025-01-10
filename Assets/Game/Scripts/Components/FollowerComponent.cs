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
            var groundTransform = _groundComponent.RycastTransform;

            if (_groundComponent.CheckGround())
            {
                transform.SetParent(groundTransform);
            }
            else
            {
                transform.SetParent(_worldTransform);
            }
        }
    }
}