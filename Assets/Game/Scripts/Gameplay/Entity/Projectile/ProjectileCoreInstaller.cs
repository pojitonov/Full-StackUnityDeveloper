using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    // TODO: Не смог разобраться как завести Trail, ошибка при сокрытии
    // Если раскоментировать Install получаю ошибку, лог ниже
    public sealed class ProjectileCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private ProjectileVisualInstaller _projectileVisualInstaller;

        public override void Install(IEntity entity)
        {
            // _projectileVisualInstaller.Install(entity);
        }
    }
}

// Cannot set the parent of the GameObject 'BulletTrail(Clone)' while activating or deactivating the parent GameObject 'Bullet(Clone)'.
// UnityEngine.Transform:set_parent (UnityEngine.Transform)
// Modules.Gameplay.TrailView/<UnspawnTrail>d__7:MoveNext () (at Assets/Modules/Trail/TrailView.cs:48)
// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskVoidMethodBuilder:Start<Modules.Gameplay.TrailView/<UnspawnTrail>d__7> (Modules.Gameplay.TrailView/<UnspawnTrail>d__7&) (at Assets/Plugins/UniTask/Runtime/CompilerServices/AsyncUniTaskVoidMethodBuilder.cs:110)
// Modules.Gameplay.TrailView:UnspawnTrail (UnityEngine.TrailRenderer)
// Modules.Gameplay.TrailView:Hide () (at Assets/Modules/Trail/TrailView.cs:41)
// Game.Gameplay.ProjectileVisualInstaller:<Install>b__1_1 () (at Assets/Game/Scripts/Gameplay/Entity/Projectile/ProjectileVisualInstaller.cs:14)
// Atomic.Entities.Entity:Disable () (at Assets/Plugins/Atomic/Entities/Scripts/Entity/Plain/Entity_Lifecycle.cs:119)
// Atomic.Entities.SceneEntity:Disable () (at Assets/Plugins/Atomic/Entities/Scripts/Entity/Mono/SceneEntity_Lifecycle.cs:59)
// Atomic.Entities.SceneEntityRunner:OnDisable () (at Assets/Plugins/Atomic/Entities/Scripts/Runner/SceneEntityRunner.cs:71)
// Atomic.Entities.SceneEntityPool:OnReturn (Atomic.Entities.SceneEntity) (at Assets/Plugins/Atomic/Entities/Scripts/Pooling/SceneEntityPool.cs:76)
// Atomic.Entities.SceneEntityPool:Return (Atomic.Entities.IEntity) (at Assets/Plugins/Atomic/Entities/Scripts/Pooling/SceneEntityPool.cs:44)
// Game.Gameplay.SpawnBulletUseCase:UnspawnBullet (Atomic.Entities.IEntity&,Game.Gameplay.IGameContext&) (at Assets/Game/Scripts/Gameplay/GameContext/Bullet/SpawnBulletUseCase.cs:22)
// Game.Gameplay.BulletUnspawnAction:Invoke () (at Assets/Game/Scripts/Gameplay/GameContext/Bullet/BulletUnspawnAction.cs:19)
// Game.Gameplay.LifetimeBehaviour:OnFixedUpdate (Atomic.Entities.IEntity&,single&) (at Assets/Game/Scripts/Gameplay/Entity/Common/Life/LifetimeBehaviour.cs:22)
// Game.Gameplay.LifetimeBehaviour:Atomic.Entities.IEntityFixedUpdate.OnFixedUpdate (Atomic.Entities.IEntity modreq(System.Runtime.InteropServices.InAttribute)&,single modreq(System.Runtime.InteropServices.InAttribute)&)
// Atomic.Entities.Entity:OnFixedUpdate (single&) (at Assets/Plugins/Atomic/Entities/Scripts/Entity/Plain/Entity_Lifecycle.cs:157)
// Atomic.Entities.Entity:Atomic.Entities.IEntity.OnFixedUpdate (single modreq(System.Runtime.InteropServices.InAttribute)&)
// Atomic.Entities.SceneEntity:OnFixedUpdate (single&) (at Assets/Plugins/Atomic/Entities/Scripts/Entity/Mono/SceneEntity_Lifecycle.cs:62)
// Atomic.Entities.SceneEntity:Atomic.Entities.IEntity.OnFixedUpdate (single modreq(System.Runtime.InteropServices.InAttribute)&)
// Atomic.Entities.SceneEntityUpdater:FixedUpdate () (at Assets/Plugins/Atomic/Entities/Scripts/Runner/SceneEntityUpdater.cs:91)
