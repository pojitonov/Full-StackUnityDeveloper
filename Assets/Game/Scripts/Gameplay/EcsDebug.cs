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
        public void DestroyEntity(DestroyRequest request)
        {
            EcsWorld eventWorld = _ecsSystems.GetWorld(EcsConsts.EventWorld);
            int evt = eventWorld.NewEntity();
            eventWorld.GetPool<DestroyRequest>().Add(evt) = request;
        }
    }
}