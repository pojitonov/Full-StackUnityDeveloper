using UnityEngine;

namespace Game.Scripts
{
    public class CharacterJumpController : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _character._jumpAction.Invoke();
            }
        }
    }
}