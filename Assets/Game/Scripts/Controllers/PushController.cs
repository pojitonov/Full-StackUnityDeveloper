using UnityEngine;

namespace Game.Scripts
{
    public sealed class PushController : MonoBehaviour
    {
        [SerializeField]
        private Character _character;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _character._pushComponent.Push();
            }

            else if (Input.GetKeyDown(KeyCode.E))
            {
                _character._pushComponent.Push();
            }
        }
    }
}