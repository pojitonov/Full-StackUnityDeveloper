using UnityEngine;
using Zenject;

namespace Game.App
{
    [CreateAssetMenu(
        fileName = "RepositoryInstaller",
        menuName = "Zenject/Installers/New RepositoryInstaller"
    )]
    public class RepositoryInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private string _uri = "http://127.0.0.1:8888";

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Repository>()
                .AsSingle()
                .WithArguments(_uri);
        }
    }
}