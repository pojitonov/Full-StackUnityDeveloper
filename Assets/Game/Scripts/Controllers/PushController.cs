using UnityEngine;

namespace Game.Scripts
{
    public sealed class PushController : MonoBehaviour
    {
        [SerializeField]
        private Character _character;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _character._pushComponent.Push(Vector2.up);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _character._pushComponent.Push(_character.MoveDirection);
            }
        }
    }
}