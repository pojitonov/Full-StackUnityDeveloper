using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
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
        // [SerializeField] private EcsPrototype _projectilePrefab;
        // [SerializeField] private int _initialMoney = 100;
        
        public IEcsSystems Create()
        {
            EcsWorld world = new EcsWorld();
            // world.AddSingleton(new InputData());
            // world.AddSingleton(new PlayerData{money = _initialMoney});
            
            EcsSystems systems = new EcsSystems(world, new GameData());
            
            systems.AddWorld(new EcsWorld(), EcsConsts.EventWorld);
            systems

                //Input:
                .Add(new InputSystem(_inputMap))
                .Add(new PlayerMoveController())

                //Game Logic
                .Add(new SpawnSystem())
                .Add(new DespawnSystem())
                .Add(new UnitMoveSystem())
                .Add(new MoveSystem())
                .Add(new RotateSystem())

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