using Zenject;

namespace SnakeGame
{
    public class InputInstaller : Installer<InputInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerController>()
                .AsSingle();
        }
    }
}