using UnityEngine;

namespace Game.Scripts
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField]
        private Character _character;
        
        private JumpComponent _jumpComponent;

        private void Awake()
        {
            _jumpComponent = _character.GetComponent<JumpComponent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                _jumpComponent.Jump();
            }
        }
    }
}