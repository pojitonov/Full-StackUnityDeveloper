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
                _character._tossComponent.Toss();
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                _character._pushComponent.Push();
            }
        }
    }
}