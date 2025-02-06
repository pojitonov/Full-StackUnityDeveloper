using Atomic.Entities;
using Modules.Common;
using UnityEngine;

namespace Game.Gameplay
{
    public class CharacterMoveController : MonoBehaviour
    {
        [SerializeField] private SceneEntity _character;
        [SerializeField] private Joystick _joystick;

        private void Awake()
        {
            InputUseCase.SetMoveJoystick(_joystick);
        }
        
        private void Update()
        {
            var direction = InputUseCase.GetMoveDirection();
            _character.GetMoveDirection().Value = direction;
        }
    }
}