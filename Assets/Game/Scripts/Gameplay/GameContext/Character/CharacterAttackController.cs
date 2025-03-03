using Atomic.Contexts;
using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public class CharacterAttackController : IContextInit<GameContext>, IContextUpdate<GameContext>
    {
        private IEntity _character;
        private Cooldown _cooldown;

        public void Init(GameContext context)
        {
            _character = context.GetCharacter();
            _cooldown = new Cooldown(_character.GetAttackDelay().Value);
        }

        public void OnUpdate(GameContext context, float deltaTime)
        {
            var direction = InputUseCase.GetDirection(context.GetAttackJoystick());
            var isAttacking = context.GetIsAttacking();

            if (direction.sqrMagnitude > 0.01f)
            {
                _character.RotateTowards(direction, deltaTime);

                if (!isAttacking.Value)
                {
                    isAttacking.Value = true;
                    _cooldown.Reset();
                }

                if (_cooldown.IsExpired())
                {
                    _character.GetAttackAction().Invoke();
                    _cooldown.Reset();
                    isAttacking.Value = false;
                }
                else
                {
                    _cooldown.Tick(deltaTime);
                }
            }
        }
    }
}