using System;
using Atomic.Contexts;
using Modules.Common;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public class InputSystemInstaller : IContextInstaller<IGameContext>
    {
        [SerializeField] private Joystick _moveJoystick;
        [SerializeField] private Joystick _attackJoystick;
        
        public void Install(IGameContext context)
        {
            context.AddMoveJoystick(_moveJoystick);
            context.AddAttackJoystick(_attackJoystick);
        }
    }
}