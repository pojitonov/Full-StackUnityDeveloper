// using Atomic.Entities;
// using Modules.Gameplay;
//
// namespace Game.Gameplay
// {
//     public static class AttackUseCase
//     {
//         public static void Attack(this IEntity entity, in Cooldown cooldown, in float deltaTime)
//         {
//             cooldown.Tick(deltaTime);
//
//             if (cooldown.IsExpired())
//             {
//                 entity.GetAttackAction().Invoke();
//                 cooldown.Reset();
//             }
//         }
//     }
// }