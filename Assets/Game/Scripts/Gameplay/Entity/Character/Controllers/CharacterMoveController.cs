using Atomic.Contexts;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class CharacterMoveController : IContextInit<GameContext>, IContextUpdate<GameContext>
    {
        private static IEntity _character;

        public void Init(GameContext context)
        {
            _character = context.GetCharacter();
        }

        public void OnUpdate(GameContext context, float deltaTime)
        {
            var direction = InputUseCase.GetDirection(context.GetMoveJoystick());
            _character.GetMoveDirection().Value = direction;
        }
    }
}