using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class EcsAdmin : MonoBehaviour
    {
        public static IEcsSystems Systems { get; private set; }

        [SerializeField] private EcsWorldView _worldView;
        [SerializeField] private EcsSystemsFactory _systemsFactory;
        [SerializeField] private EcsBaker _baker;
        
        private void Awake()
        {
            IEcsSystems systems = _systemsFactory.Create();
            _baker.BakeScene(systems.GetWorld());

            systems
                .Inject()
                .Init();

            Systems = systems;
        }

        private void Start()
        {
            _worldView.Show(Systems.GetWorld());
        }

        private void Update()
        {
            Systems?.Run();
        }

        private void OnDestroy()
        {
            Systems.GetWorld(EcsConsts.EventWorld).Destroy();
            Systems.GetWorld().Destroy();
            Systems.Destroy();
        }
    }
}