/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using System;
using UnityEngine;
using Atomic.Entities;
using Atomic.Elements;

namespace Game.Gameplay
{
	public static class EntityAPI
	{


		///Values
		public const int Transform = -180157682; // Transform
		public const int MoveSpeed = 526065662; // IValue<float>
		public const int AngularSpeed = -1089183267; // IValue<float>
		public const int MoveAction = 1225226561; // IAction<Vector3, float>
		public const int Health = -915003867; // IValue<int>


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
		public static IValue<float> GetMoveSpeed(this IEntity obj) => obj.GetValue<IValue<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IEntity obj, out IValue<float> value) => obj.TryGetValue(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveSpeed(this IEntity obj, IValue<float> value) => obj.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IEntity obj, IValue<float> value) => obj.SetValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetAngularSpeed(this IEntity obj) => obj.GetValue<IValue<float>>(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAngularSpeed(this IEntity obj, out IValue<float> value) => obj.TryGetValue(AngularSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAngularSpeed(this IEntity obj, IValue<float> value) => obj.AddValue(AngularSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAngularSpeed(this IEntity obj) => obj.HasValue(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAngularSpeed(this IEntity obj) => obj.DelValue(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAngularSpeed(this IEntity obj, IValue<float> value) => obj.SetValue(AngularSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<Vector3, float> GetMoveAction(this IEntity obj) => obj.GetValue<IAction<Vector3, float>>(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveAction(this IEntity obj, out IAction<Vector3, float> value) => obj.TryGetValue(MoveAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveAction(this IEntity obj, IAction<Vector3, float> value) => obj.AddValue(MoveAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveAction(this IEntity obj) => obj.HasValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveAction(this IEntity obj) => obj.DelValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveAction(this IEntity obj, IAction<Vector3, float> value) => obj.SetValue(MoveAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetHealth(this IEntity obj) => obj.GetValue<IValue<int>>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IEntity obj, out IValue<int> value) => obj.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHealth(this IEntity obj, IValue<int> value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IEntity obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IEntity obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IEntity obj, IValue<int> value) => obj.SetValue(Health, value);
    }
}
