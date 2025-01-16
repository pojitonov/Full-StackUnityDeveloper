using Game.Scripts.Components;
using Game.Scripts.Objects;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public sealed class PushController : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private PushObjectsComponent _pushObjectsComponent;
        private TossObjectsComponent _tossObjectsComponent;

        private void Awake()
        {
            _pushObjectsComponent = _character.GetComponent<PushObjectsComponent>();
            _tossObjectsComponent = _character.GetComponent<TossObjectsComponent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _tossObjectsComponent.Toss();
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                _pushObjectsComponent.Push();
            }
        }
    }
}