using Modules.UI;
using Zenject;

namespace Game.UI
{
    public sealed class MoneyInstaller : Installer<MoneyView, MoneyInstaller>
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
                .BindInterfacesTo<MoneyPresenter>()
                .AsCached()
                .WithArguments(_moneyView)
                .NonLazy();
            
            Container
                .BindInterfacesTo<MoneyAnimationController>()
                .AsCached()
                .NonLazy();

            Container
                .Bind<MoneyAnimation>()
                .FromComponentInHierarchy()
                .AsCached();
        }
    }
}