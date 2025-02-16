using Atomic.Contexts;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public class CharacterAttackController : IContextInit<GameContext>, IContextUpdate<GameContext>
    {
        private static Cooldown _cooldown;

        public void Init(GameContext context)
        {
            _cooldown = new Cooldown(context.GetCharacter().GetFireDelay().Value);
        }

        public void OnUpdate(GameContext context, float deltaTime)
        {
            InputUseCase.Attack(context, deltaTime, _cooldown);
        }
    }
}