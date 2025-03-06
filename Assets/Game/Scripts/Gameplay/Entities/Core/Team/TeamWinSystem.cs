using System.Collections.Generic;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class TeamWinSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<BaseTag, TeamType>> _bases;

        public void Run(IEcsSystems systems)
        {
            HashSet<TeamType> activeTeams = new HashSet<TeamType>();

            foreach (var baseEntity in _bases.Value)
            {
                var baseTeamType = _bases.Pools.Inc2.Get(baseEntity);
                activeTeams.Add(baseTeamType);
            }

            if (activeTeams.Count < 2)
            {
                Time.timeScale = 0f;
            }
        }
    }
}