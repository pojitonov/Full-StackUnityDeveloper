using Game.Scripts.Components;
using Game.Scripts.Objects;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public sealed class PushController : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private PushComponent _pushComponent;
        private TossComponent _tossComponent;

        private void Awake()
        {
            _pushComponent = _character.GetComponent<PushComponent>();
            _tossComponent = _character.GetComponent<TossComponent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _tossComponent.Toss();
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                _pushComponent.Push();
            }
        }
    }
}