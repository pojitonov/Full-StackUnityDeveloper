using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    public sealed class ArrowCollisionView : MonoBehaviour
    {
        [SerializeField] private EcsView _view;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out EcsView target))
                return;

            var collisionRequests = EcsAdmin.Systems.GetWorld().GetEvent<ArrowCollisionRequest>();
            collisionRequests.Fire(new ArrowCollisionRequest
            {
                prefab = _view.GetPackedEntity(),
                target = target.GetPackedEntity()
            });
        }
    }
}