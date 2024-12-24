using UnityEngine;
using Zenject;

namespace Game.App
{
    [CreateAssetMenu(
        fileName = "Repository Installer",
        menuName = "Zenject/Installers/RepositoryInstaller"
    )]
    public class RepositoryInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private string _uri = "http://127.0.0.1:8080";

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Repository>()
                .AsSingle()
                .WithArguments(_uri);
        }
    }
}