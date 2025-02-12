using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "EcsSystemsFactory",
        menuName = "SampleGame/Ecs/New EcsSystemsFactory"
    )]
    public sealed class EcsSystemsFactory : ScriptableObject
    {
        [SerializeField] private InputMap _inputMap;
        [SerializeField] private TeamViewConfig _teamViewConfig;
        [SerializeField] private EcsPrototype _arrowPrefab;
        
        public IEcsSystems Create()
        {
            EcsWorld world = new EcsWorld();
            EcsSystems systems = new EcsSystems(world, new GameData());
            
            systems.AddWorld(new EcsWorld(), EcsConsts.EventWorld);
            systems

                //Input:
                .Add(new InputSystem(_inputMap))
                .Add(new PlayerMoveController())
                .Add(new PlayerFireController())

                //Game Logic
                .Add(new SpawnSystem())
                .Add(new DespawnSystem())
                .Add(new LifetimeSystem())
                
                .Add(new MoveSystem())
                .Add(new RotateSystem())
                
                .Add(new UnitMoveSystem())
                .Add(new UnitFireSystem(_arrowPrefab))
                
                .Add(new FireCooldownSystem())
                .Add(new ArrowInitializeSystem())

                //Rendering:
                .Add(new TransformViewSystem())
                .Add(new TeamViewSystem(_teamViewConfig))

                //Clear:

                //Debug:
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem(EcsConsts.EventWorld));
#endif
            return systems;
        }
    }
}