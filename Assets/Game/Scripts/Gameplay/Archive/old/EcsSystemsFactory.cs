// using Leopotam.EcsLite;
// using UnityEngine;
//
// namespace SampleGame
// {
//     [CreateAssetMenu(
//         fileName = "EcsSystemsFactory",
//         menuName = "SampleGame/Ecs/New EcsSystemsFactory"
//     )]
//     public sealed class EcsSystemsFactory : ScriptableObject
//     {
//         [SerializeField] private InputMap _inputMap;
//         [SerializeField] private TeamViewConfig _teamViewConfig;
//         [SerializeField] private EcsPrototype _arrowPrefab;
//         
//         [Header("Animation Keys")]
//         [SerializeField] private string _attack = "Attack";
//         [SerializeField] private string _takeDamage = "Take Damage";
//         [SerializeField] private string _move = "IsWalking";
//         
//         [Header("Sound Clips")]
//         [SerializeField] private AudioClip _unitTakeDamage;
//         [SerializeField] private AudioClip _baseTakeDamage;
//         [SerializeField] private AudioClip _archerAttack;
//         [SerializeField] private AudioClip _swordmanAttack;
//         
//         public IEcsSystems Create()
//         {
//             EcsWorld world = new EcsWorld();
//             EcsSystems systems = new EcsSystems(world, new GameData());
//             
//             systems.AddWorld(new EcsWorld(), EcsConsts.EventWorld);
//             systems
//
//                 //Input:
//                 // .Add(new InputSystem(_inputMap))
//                 // .Add(new PlayerMoveController())
//                 // .Add(new PlayerFireController())
//
//                 //Game Logic
//                 .Add(new UnitInitSystem())
//                 .Add(new ArrowInitSystem())
//                 
//                 .Add(new SpawnSystem())
//                 .Add(new DestroySystem())
//                 .Add(new LifetimeSystem())
//                 
//                 .Add(new MoveSystem())
//                 .Add(new RotationSystem())
//                 .Add(new DeathSystem())
//                 
//                 .Add(new ArrowCollisionSystem())
//                 
//                 .Add(new UnitMoveSystem())
//                 .Add(new UnitRotateSystem())
//                 .Add(new UnitTargetSystem())
//                 .Add(new UnitDirectionSystem())
//                 .Add(new UnitFireReadySystem())
//                 .Add(new FireCooldownSystem())
//                 .Add(new UnitFireSystem(_arrowPrefab))
//
//                 //Rendering:
//                 .Add(new TransformViewSystem())
//                 .Add(new TeamViewSystem(_teamViewConfig))
//                 .Add(new FireAnimSystem(_attack))
//                 .Add(new TakeDamageAnimSystem(_takeDamage))
//                 .Add(new TakeDamageParticleSystem())
//                 .Add(new MoveAnimSystem(_move))
//                 
//                 //Audio:
//                 .Add(new UnitTakeDamageAudioSystem(_unitTakeDamage))
//                 .Add(new BaseTakeDamageAudioSystem(_baseTakeDamage))
//
//                 //Clear:
//                 .Add(new ClearEventSystem<FireEvent>(world))
//                 .Add(new ClearEventSystem<TakeDamageEvent>(world))
//
//                 //Debug:
// #if UNITY_EDITOR
//                 .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
//                 .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem(EcsConsts.EventWorld));
// #endif
//             return systems;
//         }
//     }
// }