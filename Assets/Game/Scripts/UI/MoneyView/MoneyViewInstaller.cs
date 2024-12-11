using Modules.UI;
using Zenject;

namespace Game.UI
{
    public sealed class MoneyViewInstaller : Installer<MoneyView, MoneyViewInstaller>
    {
        [Inject]
        private MoneyView _moneyView;
        
        public override void InstallBindings()
        {
            Container
                .Bind<MoneyView>()
                .FromComponentInHierarchy()
                .AsCached()
                .NonLazy();
            
            Container
                .BindInterfacesTo<MoneyViewPresenter>()
                .AsCached()
                .WithArguments(_moneyView)
                .NonLazy();

            Container
                .Bind<CounterAnimation>()
                .FromComponentInHierarchy()
                .AsCached()
                .NonLazy();
        }
    }
}