/**
* Code generation. Don't modify! 
**/

using Atomic.Contexts;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Contexts;
using Atomic.Entities;
using Atomic.Elements;

namespace Game.Gameplay
{
	public static class GameContextAPI
	{


		///Values
		public const int BulletPool = 1915726678; // IEntityPool
		public const int Target = 1103309514; // IReactiveVariable<IEntity>


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntityPool GetBulletPool(this IGameContext obj) => obj.GetValue<IEntityPool>(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPool(this IGameContext obj, out IEntityPool value) => obj.TryGetValue(BulletPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddBulletPool(this IGameContext obj, IEntityPool value) => obj.AddValue(BulletPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPool(this IGameContext obj) => obj.HasValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPool(this IGameContext obj) => obj.DelValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPool(this IGameContext obj, IEntityPool value) => obj.SetValue(BulletPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IEntity> GetTarget(this IGameContext obj) => obj.GetValue<IReactiveVariable<IEntity>>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IGameContext obj, out IReactiveVariable<IEntity> value) => obj.TryGetValue(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTarget(this IGameContext obj, IReactiveVariable<IEntity> value) => obj.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IGameContext obj) => obj.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IGameContext obj) => obj.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IGameContext obj, IReactiveVariable<IEntity> value) => obj.SetValue(Target, value);
    }
}
