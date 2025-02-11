using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    public static class TeamViewUseCase
    {
        private static Material _material;

        public static void SetTeam(in Renderer[] renderers, in TeamType teamType, in TeamViewConfig viewConfig,
            in EcsWorld world, in int entity)
        {
            TeamViewConfig.TeamInfo team = viewConfig.GetTeam(teamType);

            if (world.GetPool<BannerTag>().Has(entity))
            {
                _material = team.BannerMaterial;
            }
            else if (world.GetPool<UnitTag>().Has(entity))
            {
                _material = team.UnitMaterial;
            }
            else if (world.GetPool<BaseTag>().Has(entity))
            {
                _material = team.BaseMaterial;
            }

            for (int i = 0, count = renderers.Length; i < count; i++)
            {
                renderers[i].material = _material;
            }
        }
    }
}