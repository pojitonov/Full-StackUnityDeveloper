// using System;
// using Modules.Money;
// using Modules.UI;
// using Zenject;
//
// namespace Game.UI
// {
//     public sealed class PlanetAnimationController : IInitializable, IDisposable
//     {
//         public PlanetAnimationController()
//         {
//         }
//
//         public void Initialize()
//         {
//             _planet.OnIncomeTimeChanged += OnIncomeTimeChanged;
//         }
//
//         public void Dispose()
//         {
//             _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
//         }
//
//         private void OnPlanetClick()
//         {
//             if (_planet.IsIncomeReady)
//             {
//                 _view.StartCoinAnimation(() => { _planet.GatherIncome(); });
//             }
//         }
//
//         private void OnIncomeTimeChanged(float time)
//         {
//             _view.StartTimerAnimation(time, _planet.IncomeProgress);
//         }
//     }
// }