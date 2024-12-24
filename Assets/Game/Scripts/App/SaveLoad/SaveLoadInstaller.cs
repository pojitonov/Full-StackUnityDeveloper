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
        }
    }
}