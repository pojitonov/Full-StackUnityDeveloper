using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    // TODO: Не смог разобраться как завести Trail, ошибка при сокрытии
    public sealed class ProjectileCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private ProjectileVisualInstaller _projectileVisualInstaller;

        public override void Install(IEntity entity)
        {
            // _projectileVisualInstaller.Install(entity);
        }
    }
}