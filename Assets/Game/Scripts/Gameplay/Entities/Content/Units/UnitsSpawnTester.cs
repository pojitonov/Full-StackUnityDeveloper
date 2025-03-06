using Leopotam.EcsLite;
using SampleGame;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts
{
    public class UnitsSpawnTester : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private EcsPrototype[] units;
        
        private IEcsSystems _ecsSystems;
        private EcsWorld _world;
        private TeamType _team;

        private void Start()
        {
            _ecsSystems = EcsAdmin.Systems;
            _world = _ecsSystems.GetWorld();
        }

        [Button]
        private void SpawnUnit()
        {
            if (spawnPoints.Length == 0 || units.Length == 0 || _ecsSystems == null)
                return;

            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            var unitPrototype = units[Random.Range(0, units.Length)];

            var ecsView = GetComponentInParent<EcsView>();
            if (ecsView == null)
                return;

            int entity = ecsView.Entity;
            var world = ecsView.World;

            var teamTypePool = world.GetPool<TeamType>();
            if (teamTypePool.Has(entity))
            {
                TeamType teamType = teamTypePool.Get(entity);
                _team = teamType; 
            }
            else
            {
                return;
            }

            var pool = world.GetEvent<SpawnRequest>();
            pool.Fire(new SpawnRequest
            {
                position = spawnPoint.position,
                rotation = spawnPoint.rotation,
                prefab = unitPrototype,
                team = _team
            });
        }
    }
}
