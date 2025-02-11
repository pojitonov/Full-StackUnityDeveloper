using Leopotam.EcsLite;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame
{
    public sealed class EcsDebug : MonoBehaviour
    {
        private IEcsSystems _ecsSystems;

        private void Start()
        {
            _ecsSystems = EcsAdmin.Systems;
        }

        [Button]
        public void SpawnEntity(SpawnRequest request)
        {
            _ecsSystems.GetWorld().GetEvent<SpawnRequest>().Fire(request);
        }

        [Button]
        public void DespawnEntity(DespawnRequest request)
        {
            EcsWorld eventWorld = _ecsSystems.GetWorld(EcsConsts.EventWorld);
            int evt = eventWorld.NewEntity();
            eventWorld.GetPool<DespawnRequest>().Add(evt) = request;
        }
        
        // [Button]
        // private void CreateEntity(EcsPrototype prefab, float3 position, quaternion rotation, TeamType team)
        // {
        //     int entity = prefab.Create(_world);
        //
        //     _world.GetPool<Position>().Add(entity).value = position;
        //     _world.GetPool<Rotation>().Add(entity).value = rotation;
        // }
        //
        // [Button]
        // private void DeleteEntity(int entity)
        // {
        //     _world.DelEntity(entity);
        // }
    }
}