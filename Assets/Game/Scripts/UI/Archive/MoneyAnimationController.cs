// using System;
// using Modules.Money;
// using Zenject;
//
// namespace Game.UI.Money
// {
//     public sealed class MoneyAnimationController : IInitializable, IDisposable
//     {
//         private readonly MoneyStorage _money;
//         private readonly MoneyAnimator _animator;
//
//         public MoneyAnimationController(MoneyStorage money, MoneyAnimator animator)
//         {
//             _money = money;
//             _animator = animator;
//         }
//
//         public void Initialize()
//         {
//             _animator.Initialize(_money.Money.ToString());
//             _money.OnMoneyChanged += StartAnimation;
//         }
//
//         public void Dispose()
//         {
//             _money.OnMoneyChanged -= StartAnimation;
//         }
//
//         private void StartAnimation(int newValue, int previousValue)
//         {
//             _animator.UpdateText(newValue.ToString());
//         }
//     }
// }