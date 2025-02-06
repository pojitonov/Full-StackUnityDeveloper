using Atomic.Entities;
using Modules.Common;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public class CharacterAttackController : MonoBehaviour
    {
        [SerializeField] private SceneEntity _character;
        [SerializeField] private Joystick _joystick;

        private Cooldown _cooldown;

        private void Awake()
        {
            InputUseCase.SetAttackJoystick(_joystick);
            _cooldown = new Cooldown(_character.GetFireDuration().Value);
        }

        private void Update()
        {
            InputUseCase.Attack(_character, _cooldown);
        }
    }
}