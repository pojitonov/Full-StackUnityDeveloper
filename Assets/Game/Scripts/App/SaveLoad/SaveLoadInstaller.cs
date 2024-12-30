using SampleGame.Gameplay;
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
            
            Container.Bind<Countdown>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.Bind<DestinationPoint>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.Bind<Health>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.Bind<ProductionOrder>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.Bind<ResourceBag>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.Bind<TargetObject>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.Bind<Team>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}