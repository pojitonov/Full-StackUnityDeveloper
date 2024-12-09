using Zenject;

namespace SnakeGame
{
    public class _UIInstaller : Installer<_UIInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIDifficultyController>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<UIGameOverController>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<UIScoreController>()
                .AsSingle();
        }
    }
}