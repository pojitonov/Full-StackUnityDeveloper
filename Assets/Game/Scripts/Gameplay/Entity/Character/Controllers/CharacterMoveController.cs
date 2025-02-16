using Atomic.Contexts;

namespace Game.Gameplay
{
    public class CharacterMoveController : IContextUpdate<GameContext>
    {
        public void OnUpdate(GameContext context, float deltaTime)
        {
            var direction = InputUseCase.GetDirection(context.GetMoveJoystick());
            context.GetCharacter().GetMoveDirection().Value = direction;
        }
    }
}