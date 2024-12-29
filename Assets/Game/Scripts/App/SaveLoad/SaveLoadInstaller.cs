using Modules.Entities;
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
            
            Container.BindInterfacesTo<Serializer_Countdown>()
                .AsSingle();
            Container.BindInterfacesTo<Serializer_DestinationPoint>()
                .AsSingle();
            Container.BindInterfacesTo<Serializer_Health>()
                .AsSingle();
            Container.BindInterfacesTo<Serializer_ProductionOrder>()
                .AsSingle();
            Container.BindInterfacesTo<Serializer_ResourceBag>()
                .AsSingle();
            Container.BindInterfacesTo<Serializer_TargetObject>()
                .AsSingle();
            Container.BindInterfacesTo<Serializer_Team>()
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