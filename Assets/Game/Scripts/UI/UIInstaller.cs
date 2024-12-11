using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField]
        private MoneyView moneyView;

        public override void InstallBindings()
        {
            MoneyViewInstaller.Install(Container, moneyView);
        }
    }
}