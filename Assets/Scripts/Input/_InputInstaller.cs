using Zenject;

namespace SnakeGame
{
    public class _InputInstaller : Installer<_InputInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerController>()
                .AsSingle();
        }
    }
}