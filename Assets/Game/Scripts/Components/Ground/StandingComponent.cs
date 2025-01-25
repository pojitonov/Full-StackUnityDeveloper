using UnityEngine;

namespace Game.Scripts.Components
{
    public class StandingComponent : MonoBehaviour
    {
        [SerializeField] private GroundComponent _groundComponent;

        private Transform _worldTransform;

        public void UpdateStanding(bool isGrounded, Transform groundTransform)
        {
            transform.SetParent(isGrounded ? groundTransform : _worldTransform);
        }
    }
}