using UnityEngine;

namespace Game.Scripts
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _character._jumpComponent.Jump();
            }
        }
    }
}