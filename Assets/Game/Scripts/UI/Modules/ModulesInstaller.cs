using Modules.UI;
using Zenject;

namespace Game.UI
{
    public sealed class ModulesInstaller : Installer<ModulesInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CounterAnimation>()
                .FromComponentInHierarchy()
                .AsCached()
                .NonLazy();
        }
    }
}