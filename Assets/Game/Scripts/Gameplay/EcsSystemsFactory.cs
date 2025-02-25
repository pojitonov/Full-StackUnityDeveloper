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

        [Header("Animation Keys")]
        [SerializeField] private string _attack = "Attack";
        [SerializeField] private string _takeDamage = "Take Damage";
        [SerializeField] private string _move = "IsWalking";

        [Header("Sound Clips")]
        [SerializeField] private AudioClip _unitTakeDamage;
        [SerializeField] private AudioClip _baseTakeDamage;
        [SerializeField] private AudioClip _archerAttack;
        [SerializeField] private AudioClip _swordmanAttack;
        
        [Header("Animation Events")]
        [SerializeField] private string _attackEvent = "OnAttackAnimation";

        public IEcsSystems Create()
        {
            EcsWorld world = new EcsWorld();
            EcsSystems systems = new EcsSystems(world, new GameData());

            systems.AddWorld(new EcsWorld(), EcsConsts.EventWorld);
            systems

                //INPUT:
                // .Add(new InputSystem(_inputMap))
                // .Add(new PlayerMoveController())
                // .Add(new PlayerFireController())

                //GAME_LOGIC:
                //Init:
                // .Add(new UnitInitSystem())
                .Add(new ArrowInitSystem())
                .Add(new AnimationEventInitSystem(_attackEvent))
                //Move:
                .Add(new MoveSystem())
                .Add(new RotationSystem())
                //Lifetime:
                .Add(new LifetimeSystem())
                .Add(new DeathSystem())
                //Unit:
                .Add(new UnitMoveSystem())
                .Add(new UnitRotateSystem())
                .Add(new UnitTargetSystem())
                .Add(new UnitStoppingDistanceSystem())
                //Attack:
                .Add(new UnitDirectionSystem())
                // .Add(new UnitAttackSystem())
                .Add(new UnitFireReadySystem())
                .Add(new UnitFireSystem(_arrowPrefab))
                .Add(new FireCooldownSystem())
                //Arrow:
                .Add(new ArrowCollisionSystem())
                //Spawn:
                .Add(new SpawnSystem())
                .Add(new DestroySystem())

                //RENDERING:
                .Add(new TransformViewSystem())
                .Add(new TeamViewSystem(_teamViewConfig))
                .Add(new FireAnimSystem(_attack))
                .Add(new TakeDamageAnimSystem(_takeDamage))
                .Add(new TakeDamageParticleSystem())
                .Add(new MoveAnimSystem(_move))

                //AUDIO:
                .Add(new UnitTakeDamageAudioSystem(_unitTakeDamage))
                .Add(new BaseTakeDamageAudioSystem(_baseTakeDamage))

                //CLEAR:
                .Add(new ClearEventSystem<FireEvent>(world))
                .Add(new ClearEventSystem<TakeDamageEvent>(world))
                .Add(new ClearEventSystem<OnAttackAnimationEvent>(world))

                //DEBUG:
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem(EcsConsts.EventWorld));
#endif
            return systems;
        }
    }
}