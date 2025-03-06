using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public readonly struct FireCooldownUseCase
    {
        private readonly EcsPoolInject<FireCooldown> _fireCooldown;

        public bool IsCooldownExpired(in int entity)
        {
            ref FireCooldown cooldown = ref _fireCooldown.Value.Get(entity);
            return cooldown.current <= 0;
        }

        public void ResetCooldown(int entity)
        {
            ref FireCooldown cooldown = ref _fireCooldown.Value.Get(entity);
            cooldown.current = cooldown.duration;
        }
    }
}