using Zenject;

namespace SnakeGame
{
    public class UIInstaller : Installer<UIInstaller>
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