using UnityEngine;

namespace Game
{
    public class StandingComponent : MonoBehaviour
    {
        [SerializeField] private GroundComponent _groundComponent;
        
        private Transform _worldTransform;

        public void FixedUpdate()
        {
            transform.SetParent(_groundComponent.IsGrounded ? _groundComponent.Transform : _worldTransform);
        }
    }
}