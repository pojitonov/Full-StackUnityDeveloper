using Zenject;

namespace Game.UI.Money
{
    public sealed class MoneyInstaller : Installer<MoneyInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<MoneyView>()
                .FromComponentInHierarchy()
                .AsCached()
                .NonLazy();
            
            Container
                .BindInterfacesTo<MoneyPresenter>()
                .AsCached()
                .NonLazy();
        }
    }
}