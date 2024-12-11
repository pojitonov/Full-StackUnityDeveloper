using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField]
        private MoneyView _moneyView;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<MoneyPresenter>()
                .AsCached()
                .WithArguments(_moneyView)
                .NonLazy();
        }
    }
}