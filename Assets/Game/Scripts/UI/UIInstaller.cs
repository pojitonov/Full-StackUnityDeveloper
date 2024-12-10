using Zenject;

namespace Game.UI
{
    public sealed class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<MoneyWidget>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}