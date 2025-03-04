using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class HideBannersSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<BannerTag, TeamType>> _banners;
        private readonly EcsFilterInject<Inc<BaseTag, TeamType>> _bases;
        private readonly EcsUseCaseInject<HideUseCase> _hideUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (var bannerEntity in _banners.Value)
            {
                _hideUseCase.Value.HideBanners(bannerEntity, _bases.Value);
            }
        }
    }
}