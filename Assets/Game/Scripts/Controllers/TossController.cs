using UnityEngine;

namespace Game.Scripts
{
    public sealed class TossController : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        private TossComponent _tossComponent;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _character._tossComponent.Toss();
            }
        }
    }
}