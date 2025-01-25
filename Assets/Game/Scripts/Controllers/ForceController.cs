using Game.Scripts.Components;
using Game.Scripts.Objects;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public sealed class ForceController : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private ForceActionComponent _forceActionComponent;
        private LookAtComponent _lookAtComponent;

        private void Awake()
        {
            _forceActionComponent = _character.GetComponent<ForceActionComponent>();
            _lookAtComponent = _character.GetComponent<LookAtComponent>();
        }

        private void Update()
        {
            var lookDirection = _lookAtComponent.Direction;
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                _forceActionComponent.ApplyForce(Vector3.up, lookDirection);
                _forceActionComponent.InvokeToss();
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                _forceActionComponent.ApplyForce(lookDirection, lookDirection);
                _forceActionComponent.InvokePush();
            }
        }
    }
}