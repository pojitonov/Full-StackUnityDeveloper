using UnityEngine;

namespace Game.Scripts
{
    public sealed class PushController : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private PushComponent _pushComponent;
        private LookAtComponent _lookAtComponent;

        private void Awake()
        {
            _pushComponent = _character.GetComponent<PushComponent>();
            _lookAtComponent = _character.GetComponent<LookAtComponent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _pushComponent.Push(Vector2.up);
            }

            var direction = _lookAtComponent.LookAtDirection;
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                _pushComponent.Push(direction);
            }
        }
    }
}