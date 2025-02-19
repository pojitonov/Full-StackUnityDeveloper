/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Modules.Gameplay;
using Atomic.Elements;

namespace Game.Gameplay
{
	public static class WeaponEntityAPI
	{


		///Values
		public const int Root = -1228515739; // IEntity
		public const int Transform = -180157682; // Transform
		public const int BulletPrefab = -918778767; // SceneEntity
		public const int Ammo = 1337839892; // Ammo
		public const int AttackAction = 203766724; // IAction


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntity GetRoot(this IWeaponEntity obj) => obj.GetValue<IEntity>(Root);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRoot(this IWeaponEntity obj, out IEntity value) => obj.TryGetValue(Root, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRoot(this IWeaponEntity obj, IEntity value) => obj.AddValue(Root, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRoot(this IWeaponEntity obj) => obj.HasValue(Root);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRoot(this IWeaponEntity obj) => obj.DelValue(Root);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRoot(this IWeaponEntity obj, IEntity value) => obj.SetValue(Root, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IWeaponEntity obj) => obj.GetValue<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IWeaponEntity obj, out Transform value) => obj.TryGetValue(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTransform(this IWeaponEntity obj, Transform value) => obj.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IWeaponEntity obj) => obj.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IWeaponEntity obj) => obj.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IWeaponEntity obj, Transform value) => obj.SetValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetBulletPrefab(this IWeaponEntity obj) => obj.GetValue<SceneEntity>(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPrefab(this IWeaponEntity obj, out SceneEntity value) => obj.TryGetValue(BulletPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddBulletPrefab(this IWeaponEntity obj, SceneEntity value) => obj.AddValue(BulletPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPrefab(this IWeaponEntity obj) => obj.HasValue(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPrefab(this IWeaponEntity obj) => obj.DelValue(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPrefab(this IWeaponEntity obj, SceneEntity value) => obj.SetValue(BulletPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Ammo GetAmmo(this IWeaponEntity obj) => obj.GetValue<Ammo>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IWeaponEntity obj, out Ammo value) => obj.TryGetValue(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAmmo(this IWeaponEntity obj, Ammo value) => obj.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IWeaponEntity obj) => obj.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IWeaponEntity obj) => obj.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IWeaponEntity obj, Ammo value) => obj.SetValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetAttackAction(this IWeaponEntity obj) => obj.GetValue<IAction>(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackAction(this IWeaponEntity obj, out IAction value) => obj.TryGetValue(AttackAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackAction(this IWeaponEntity obj, IAction value) => obj.AddValue(AttackAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackAction(this IWeaponEntity obj) => obj.HasValue(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackAction(this IWeaponEntity obj) => obj.DelValue(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackAction(this IWeaponEntity obj, IAction value) => obj.SetValue(AttackAction, value);
    }
}
