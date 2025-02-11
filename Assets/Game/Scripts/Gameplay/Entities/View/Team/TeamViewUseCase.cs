using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    public static class TeamViewUseCase
    {
        public static void SetTeam(in Renderer[] renderers, in TeamType teamType, in TeamViewConfig viewConfig, in EcsWorld world, in int entity)
        {
            TeamViewConfig.TeamInfo team = viewConfig.GetTeam(teamType);

            bool isBase = world.GetPool<BaseTag>().Has(entity);
            Material material = isBase ? team.BaseMaterial : team.UnitMaterial;

            for (int i = 0, count = renderers.Length; i < count; i++)
            {
                renderers[i].material = material;
            }
        }
    }
}