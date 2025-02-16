/**
* Code generation. Don't modify! 
**/

using Atomic.Contexts;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Contexts;
using Atomic.Entities;
using Atomic.Elements;
using Modules.Common;

namespace Game.Gameplay
{
	public static class GameContextAPI
	{


		///Values
		public const int BulletPool = 1915726678; // IEntityPool
		public const int Character = 294335127; // IEntity
		public const int Kills = -291106651; // IReactiveVariable<int>
		public const int MoveJoystick = -1686028204; // Joystick
		public const int AttackJoystick = 1168591300; // Joystick
		public const int IsFiring = 1842027070; // IValue<bool>


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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetKills(this IGameContext obj) => obj.GetValue<IReactiveVariable<int>>(Kills);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetKills(this IGameContext obj, out IReactiveVariable<int> value) => obj.TryGetValue(Kills, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddKills(this IGameContext obj, IReactiveVariable<int> value) => obj.AddValue(Kills, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasKills(this IGameContext obj) => obj.HasValue(Kills);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelKills(this IGameContext obj) => obj.DelValue(Kills);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetKills(this IGameContext obj, IReactiveVariable<int> value) => obj.SetValue(Kills, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Joystick GetMoveJoystick(this IGameContext obj) => obj.GetValue<Joystick>(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveJoystick(this IGameContext obj, out Joystick value) => obj.TryGetValue(MoveJoystick, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveJoystick(this IGameContext obj, Joystick value) => obj.AddValue(MoveJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveJoystick(this IGameContext obj) => obj.HasValue(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveJoystick(this IGameContext obj) => obj.DelValue(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveJoystick(this IGameContext obj, Joystick value) => obj.SetValue(MoveJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Joystick GetAttackJoystick(this IGameContext obj) => obj.GetValue<Joystick>(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackJoystick(this IGameContext obj, out Joystick value) => obj.TryGetValue(AttackJoystick, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackJoystick(this IGameContext obj, Joystick value) => obj.AddValue(AttackJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackJoystick(this IGameContext obj) => obj.HasValue(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackJoystick(this IGameContext obj) => obj.DelValue(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackJoystick(this IGameContext obj, Joystick value) => obj.SetValue(AttackJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<bool> GetIsFiring(this IGameContext obj) => obj.GetValue<IValue<bool>>(IsFiring);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetIsFiring(this IGameContext obj, out IValue<bool> value) => obj.TryGetValue(IsFiring, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddIsFiring(this IGameContext obj, IValue<bool> value) => obj.AddValue(IsFiring, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasIsFiring(this IGameContext obj) => obj.HasValue(IsFiring);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelIsFiring(this IGameContext obj) => obj.DelValue(IsFiring);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetIsFiring(this IGameContext obj, IValue<bool> value) => obj.SetValue(IsFiring, value);
    }
}
