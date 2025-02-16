using Atomic.Contexts;

namespace Game.Gameplay
{
    public class CharacterMoveController : IContextUpdate<GameContext>
    {
        public void OnUpdate(GameContext context, float deltaTime)
        {
            var direction = InputUseCase.GetMoveDirection(context);
            context.GetCharacter().GetMoveDirection().Value = direction;
        }
    }
}