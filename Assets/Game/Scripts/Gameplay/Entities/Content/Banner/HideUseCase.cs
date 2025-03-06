using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public readonly struct HideUseCase
    {
        private readonly EcsPoolInject<TeamType> _teamTypes;
        private readonly EcsEventInject<DespawnRequest> _destroyRequests;

        public void HideBanners(int bannerEntity, EcsFilter bases)
        {
            var bannerTeamType = _teamTypes.Value.Get(bannerEntity);
            bool foundBase = false;

            foreach (var baseEntity in bases)
            {
                if (_teamTypes.Value.Get(baseEntity) == bannerTeamType)
                {
                    foundBase = true;
                    break;
                }
            }

            if (!foundBase)
            {
                _destroyRequests.Value.Fire(new DespawnRequest { entity = bannerEntity });
            }
        }
    }
}