using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public class AttackBehaviour : IEntityInit, IEntityUpdate
    {
        private readonly Cooldown _cooldown;

        public AttackBehaviour(float attackInterval)
        {
            _cooldown = new Cooldown(attackInterval);
        }

        public void Init(in IEntity entity)
        {
            _cooldown.Reset();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _cooldown.Tick(deltaTime);

            if (_cooldown.IsExpired())
            {
                entity.GetAttackAction().Invoke();
                _cooldown.Reset();
            }
        }
    }
}