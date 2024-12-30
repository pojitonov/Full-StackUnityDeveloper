using UnityEngine;
using Zenject;

namespace Game.App
{
    [CreateAssetMenu(
        fileName = "SaveLoadInstaller",
        menuName = "Zenject/Installers/New SaveLoadInstaller"
    )]
    public class SaveLoadInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SaveLoader>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<EntitySerializer>()
                .AsSingle();

            Container.BindInterfacesTo<WorldSerializer>()
                .AsSingle();
            Container.BindInterfacesTo<CountdownSerializer>()
                .AsSingle();
            Container.BindInterfacesTo<DestinationPointSerializer>()
                .AsSingle();
            Container.BindInterfacesTo<HealthSerializer>()
                .AsSingle();
            Container.BindInterfacesTo<ProductionOrderSerializer>()
                .AsSingle();
            Container.BindInterfacesTo<ResourceBagSerializer>()
                .AsSingle();
            Container.BindInterfacesTo<TargetObjectSerializer>()
                .AsSingle();
            Container.BindInterfacesTo<TeamSerializer>()
                .AsSingle();
        }
    }
}