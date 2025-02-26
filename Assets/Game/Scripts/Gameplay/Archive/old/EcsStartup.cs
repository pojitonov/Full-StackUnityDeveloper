// using Leopotam.EcsLite;
// using Leopotam.EcsLite.Di;
// using Sirenix.OdinInspector;
// using Unity.Mathematics;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class EcsStartup : MonoBehaviour
//     {
//         [SerializeField] private EcsWorldView _worldView;
//         [SerializeField] private InputMap _inputMap;
//         
//         private EcsWorld _world;
//         private IEcsSystems _systems;
//
//         private void Awake()
//         {
//             _world = new EcsWorld();
//             _systems = new EcsSystems(_world, new GameData());
//             _systems
//                 //Input:
//                 .Add(new InputSystem(_inputMap))
//                 .Add(new PlayerMoveController())
//
//                 //Game Logic:
//                 .Add(new CharacterMoveSystem())
//                 .Add(new MoveSystem())
//                 .Add(new RotateSystem())
//
//                 //Rendering:
//                 .Add(new TransformViewSystem())
//
// #if UNITY_EDITOR
//                 .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
// #endif
//                 .Inject()
//                 .Init();
//         }
//
//         private void Start()
//         {
//             _worldView.Show(_world);
//         }
//
//         private void Update()
//         {
//             _systems?.Run();
//         }
//
//         private void OnDestroy()
//         {
//             if (_systems != null)
//             {
//                 _systems.Destroy();
//                 _systems = null;
//             }
//
//             if (_world != null)
//             {
//                 _world.Destroy();
//                 _world = null;
//             }
//         }
//
//         [Button]
//         private void CreateEntity(EscPrototype prefab, float3 position, quaternion rotation)
//         {
//             int entity = prefab.Create(_world);
//
//             _world.GetPool<Position>().Add(entity).value = position;
//             _world.GetPool<Rotation>().Add(entity).value = rotation;
//         }
//
//         [Button]
//         private void DeleteEntity(int entity)
//         {
//             _world.DelEntity(entity);
//         }
//     }
// }