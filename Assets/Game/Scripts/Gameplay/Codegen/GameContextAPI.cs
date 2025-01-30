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
		public const int Character = 294335127; // IEntity


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
		public static IEntity GetCharacter(this IGameContext obj) => obj.GetValue<IEntity>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IGameContext obj, out IEntity value) => obj.TryGetValue(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacter(this IGameContext obj, IEntity value) => obj.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IGameContext obj) => obj.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IGameContext obj) => obj.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IGameContext obj, IEntity value) => obj.SetValue(Character, value);
    }
}
