using System;
using Atomic.Contexts;
using Atomic.Elements;
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
            
            //Move:
            context.AddMoveJoystick(_moveJoystick);
            context.AddController<CharacterMoveController>();
            
            //Attack:
            context.AddAttackJoystick(_attackJoystick);
            context.AddIsAttacking(new ReactiveBool());
            context.AddController<CharacterAttackController>();
        }
    }
}