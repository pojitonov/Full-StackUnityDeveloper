using Game.Scripts.Components;
using Game.Scripts.Objects;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public sealed class ForceController : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private ForceComponent _forceComponent;
        private LookAtComponent _lookAtComponent;

        private void Awake()
        {
            _forceComponent = _character.GetComponent<ForceComponent>();
            _lookAtComponent = _character.GetComponent<LookAtComponent>();
        }

        private void Update()
        {
            var lookDirection = _lookAtComponent.Direction;
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                _forceComponent.ApplyForce(Vector3.up, lookDirection);
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                _forceComponent.ApplyForce(lookDirection, lookDirection);
            }
        }
    }
}