using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class HideBannersSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<DespawnRequest> _destroyRequests;
        
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<BannerTag, TeamType>> _banners;
        private readonly EcsFilterInject<Inc<BaseTag, TeamType>> _bases;

        public void Run(IEcsSystems systems)
        {
            foreach (var bannerEntity in _banners.Value)
            {
                var bannerTeamType = _banners.Pools.Inc2.Get(bannerEntity);
                bool hasBaseWithSameTeam = false;

                foreach (var baseEntity in _bases.Value)
                {
                    var baseTeamType = _bases.Pools.Inc2.Get(baseEntity);
                    if (bannerTeamType == baseTeamType)
                    {
                        hasBaseWithSameTeam = true;
                        break;
                    }
                }

                if (!hasBaseWithSameTeam)
                {
                    _destroyRequests.Value.Fire(new DespawnRequest { entity = bannerEntity });
                }
            }
        }
    }
}