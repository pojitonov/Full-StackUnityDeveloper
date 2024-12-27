// using System;
// using Modules.Planets;
// using Zenject;
//
// namespace Game.UI.Planet
// {
//     public sealed class CoinAnimationController : IInitializable, IDisposable
//     {
//         private readonly IPlanet _planet;
//         private readonly PlanetView _view;
//         private readonly CoinAnimation _animation;
//
//         public CoinAnimationController(IPlanet planet, PlanetView view, CoinAnimation animation)
//         {
//             _planet = planet;
//             _view = view;
//             _animation = animation;
//         }
//
//         public void Initialize()
//         {
//             _view.OnPlanetClick += StartAnimation;
//         }
//
//         public void Dispose()
//         {
//             _view.OnPlanetClick -= StartAnimation;
//         }
//
//         private void StartAnimation()
//         {
//             if (_planet.IsIncomeReady) 
//                 _animation.StartAnimation();
//         }
//     }
// }