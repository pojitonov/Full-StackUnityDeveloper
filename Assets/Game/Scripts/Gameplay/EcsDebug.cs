using Leopotam.EcsLite;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    public sealed class EcsDebug : MonoBehaviour
    {
        private EcsWorld _world;

        private void Awake()
        {
            _world = EcsAdmin.Systems.GetWorld();
        }

        [Button]
        private void CreateEntity(EscPrototype prefab, float3 position, quaternion rotation)
        {
            int entity = prefab.Create(_world);

            _world.GetPool<Position>().Add(entity).value = position;
            _world.GetPool<Rotation>().Add(entity).value = rotation;
        }

        [Button]
        private void DeleteEntity(int entity)
        {
            _world.DelEntity(entity);
        }
    }
}