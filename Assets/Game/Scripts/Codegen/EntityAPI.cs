/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;

namespace Game.Gameplay
{
	public static class EntityAPI
	{


		///Values
		public const int Transform = -180157682; // Transform
		public const int MoveSpeed = 526065662; // float
		public const int AngularSpeed = -1089183267; // float


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IEntity obj) => obj.GetValue<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IEntity obj, out Transform value) => obj.TryGetValue(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTransform(this IEntity obj, Transform value) => obj.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IEntity obj) => obj.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IEntity obj) => obj.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IEntity obj, Transform value) => obj.SetValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetMoveSpeed(this IEntity obj) => obj.GetValue<float>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IEntity obj, out float value) => obj.TryGetValue(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveSpeed(this IEntity obj, float value) => obj.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IEntity obj, float value) => obj.SetValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetAngularSpeed(this IEntity obj) => obj.GetValue<float>(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAngularSpeed(this IEntity obj, out float value) => obj.TryGetValue(AngularSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAngularSpeed(this IEntity obj, float value) => obj.AddValue(AngularSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAngularSpeed(this IEntity obj) => obj.HasValue(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAngularSpeed(this IEntity obj) => obj.DelValue(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAngularSpeed(this IEntity obj, float value) => obj.SetValue(AngularSpeed, value);
    }
}
