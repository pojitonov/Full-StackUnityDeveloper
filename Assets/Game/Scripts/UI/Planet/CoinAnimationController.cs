// using System;
// using Modules.Planets;
// using Modules.UI;
// using UnityEngine;
// using Zenject;
//
// namespace Game.UI.Planet
// {
//     public class PlanetAnimationMediator : IInitializable, IDisposable
//     {
//         [SerializeField]
//         private FlyingAnimation _animation;
//
//         private readonly IPlanet _planet;
//         private readonly PlanetView _view;
//         // private Coroutine _timerCoroutine;
//
//         public PlanetAnimationMediator(IPlanet planet, PlanetView view)
//         {
//             _planet = planet;
//             _view = view;
//         }
//
//         public void Initialize()
//         {
//             _planet.OnIncomeTimeChanged += OnIncomeTimeChanged;
//             _view.OnPlanetClick += OnPlanetClick;
//         }
//
//         public void Dispose()
//         {
//             _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
//             _view.OnPlanetClick -= OnPlanetClick;
//         }
//
//         private void OnPlanetClick()
//         {
//             if (_planet.IsIncomeReady) 
//                 StartCoinAnimation(() => { _planet.GatherIncome(); });
//         }
//         
//         private void OnIncomeTimeChanged(float time)
//         {
//             // StartTimerAnimation(time, _planet.IncomeProgress);
//         }
//
//         private void StartCoinAnimation(Action OnComplete)
//         {
//             _animation?.FlyCoinToWidget(OnComplete);
//             if (_animation == null)
//                 OnComplete?.Invoke();
//         }

        // private void StartTimerAnimation(float time, float progress)
        // {
        //     if (_timerCoroutine != null) 
        //         StopCoroutine(_timerCoroutine);
        //
        //     _timerCoroutine = StartCoroutine(AnimateTimer(time, progress));
        // }
        //
        // private IEnumerator AnimateTimer(float time, float progress)
        // {
        //     while (time > 0)
        //     {
        //         _view.ShowTimer(true);
        //         _view.ShowCoin(false);
        //
        //         _view.SetTime(time.ToString("0m:00s"));
        //         _view.SetProgress(progress);
        //         yield return null;
        //     }
        //     _view.ShowTimer(false);
        //     _view.ShowCoin(true);
        // }
//     }
// }