/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Elements;
using Modules.Gameplay;

namespace Game.Gameplay
{
	public static class EntityAPI
	{
		///Tags
		public const int Enemy = 979269037;
		public const int Character = 294335127;
		public const int Damageable = 563499515;
		public const int Interactable = 1077199658;


		///Values
		public const int GameObject = 1482111001; // GameObject
		public const int Transform = -180157682; // Transform
		public const int Weapon = 1855955664; // IWeaponEntity
		public const int Health = -915003867; // Health
		public const int Damage = 375673178; // IValue<DamageArgs>
		public const int TakeDamageEvent = 1486057413; // IEvent<DamageArgs>
		public const int DeathEvent = -1096613677; // IEvent<DamageArgs>
		public const int Lifetime = -997109026; // Cooldown
		public const int DestroyAction = 85938956; // IAction
		public const int MoveSpeed = 526065662; // IValue<float>
		public const int MoveCondition = 1466174948; // IExpression<bool>
		public const int MoveDirection = -721923052; // IReactiveVariable<Vector3>
		public const int AngularSpeed = -1089183267; // IValue<float>
		public const int RotateCondition = 1109699557; // IExpression<bool>
		public const int Target = 1103309514; // IEntity
		public const int AttackDelay = 1610191294; // IValue<float>
		public const int AttackEvent = -691201150; // IEvent
		public const int AttackAction = 203766724; // IAction
		public const int AttackCondition = -1481262935; // IFunction<bool>
		public const int InteractAction = -1026843572; // IAction<IEntity>
		public const int Collision = -650338019; // CollisionEventReceiver
		public const int Trigger = -707381567; // TriggerEventReceiver
		public const int Animator = -1714818978; // Animator
		public const int AnimationEventReceiver = 1837262450; // AnimationEventReceiver
		public const int AudioSource = 907064781; // AudioSource


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEnemyTag(this IEntity obj) => obj.HasTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddEnemyTag(this IEntity obj) => obj.AddTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEnemyTag(this IEntity obj) => obj.DelTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacterTag(this IEntity obj) => obj.HasTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacterTag(this IEntity obj) => obj.AddTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacterTag(this IEntity obj) => obj.DelTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageableTag(this IEntity obj) => obj.HasTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageableTag(this IEntity obj) => obj.AddTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageableTag(this IEntity obj) => obj.DelTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractableTag(this IEntity obj) => obj.HasTag(Interactable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractableTag(this IEntity obj) => obj.AddTag(Interactable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractableTag(this IEntity obj) => obj.DelTag(Interactable);


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameObject GetGameObject(this IEntity obj) => obj.GetValue<GameObject>(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameObject(this IEntity obj, out GameObject value) => obj.TryGetValue(GameObject, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddGameObject(this IEntity obj, GameObject value) => obj.AddValue(GameObject, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameObject(this IEntity obj) => obj.HasValue(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameObject(this IEntity obj) => obj.DelValue(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameObject(this IEntity obj, GameObject value) => obj.SetValue(GameObject, value);

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
		public static IWeaponEntity GetWeapon(this IEntity obj) => obj.GetValue<IWeaponEntity>(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeapon(this IEntity obj, out IWeaponEntity value) => obj.TryGetValue(Weapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddWeapon(this IEntity obj, IWeaponEntity value) => obj.AddValue(Weapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeapon(this IEntity obj) => obj.HasValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeapon(this IEntity obj) => obj.DelValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeapon(this IEntity obj, IWeaponEntity value) => obj.SetValue(Weapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Health GetHealth(this IEntity obj) => obj.GetValue<Health>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IEntity obj, out Health value) => obj.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHealth(this IEntity obj, Health value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IEntity obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IEntity obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IEntity obj, Health value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<DamageArgs> GetDamage(this IEntity obj) => obj.GetValue<IValue<DamageArgs>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IEntity obj, out IValue<DamageArgs> value) => obj.TryGetValue(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamage(this IEntity obj, IValue<DamageArgs> value) => obj.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IEntity obj) => obj.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IEntity obj) => obj.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IEntity obj, IValue<DamageArgs> value) => obj.SetValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<DamageArgs> GetTakeDamageEvent(this IEntity obj) => obj.GetValue<IEvent<DamageArgs>>(TakeDamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTakeDamageEvent(this IEntity obj, out IEvent<DamageArgs> value) => obj.TryGetValue(TakeDamageEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTakeDamageEvent(this IEntity obj, IEvent<DamageArgs> value) => obj.AddValue(TakeDamageEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTakeDamageEvent(this IEntity obj) => obj.HasValue(TakeDamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTakeDamageEvent(this IEntity obj) => obj.DelValue(TakeDamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTakeDamageEvent(this IEntity obj, IEvent<DamageArgs> value) => obj.SetValue(TakeDamageEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<DamageArgs> GetDeathEvent(this IEntity obj) => obj.GetValue<IEvent<DamageArgs>>(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeathEvent(this IEntity obj, out IEvent<DamageArgs> value) => obj.TryGetValue(DeathEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDeathEvent(this IEntity obj, IEvent<DamageArgs> value) => obj.AddValue(DeathEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeathEvent(this IEntity obj) => obj.HasValue(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeathEvent(this IEntity obj) => obj.DelValue(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeathEvent(this IEntity obj, IEvent<DamageArgs> value) => obj.SetValue(DeathEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetLifetime(this IEntity obj) => obj.GetValue<Cooldown>(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLifetime(this IEntity obj, out Cooldown value) => obj.TryGetValue(Lifetime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddLifetime(this IEntity obj, Cooldown value) => obj.AddValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLifetime(this IEntity obj) => obj.HasValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLifetime(this IEntity obj) => obj.DelValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLifetime(this IEntity obj, Cooldown value) => obj.SetValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetDestroyAction(this IEntity obj) => obj.GetValue<IAction>(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDestroyAction(this IEntity obj, out IAction value) => obj.TryGetValue(DestroyAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDestroyAction(this IEntity obj, IAction value) => obj.AddValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDestroyAction(this IEntity obj) => obj.HasValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDestroyAction(this IEntity obj) => obj.DelValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDestroyAction(this IEntity obj, IAction value) => obj.SetValue(DestroyAction, value);

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
		public static IExpression<bool> GetMoveCondition(this IEntity obj) => obj.GetValue<IExpression<bool>>(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(MoveCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCondition(this IEntity obj) => obj.HasValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCondition(this IEntity obj) => obj.DelValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Vector3> GetMoveDirection(this IEntity obj) => obj.GetValue<IReactiveVariable<Vector3>>(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveDirection(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValue(MoveDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(MoveDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveDirection(this IEntity obj) => obj.HasValue(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveDirection(this IEntity obj) => obj.DelValue(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(MoveDirection, value);

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
		public static IExpression<bool> GetRotateCondition(this IEntity obj) => obj.GetValue<IExpression<bool>>(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(RotateCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRotateCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(RotateCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateCondition(this IEntity obj) => obj.HasValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateCondition(this IEntity obj) => obj.DelValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(RotateCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntity GetTarget(this IEntity obj) => obj.GetValue<IEntity>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IEntity obj, out IEntity value) => obj.TryGetValue(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTarget(this IEntity obj, IEntity value) => obj.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IEntity obj) => obj.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IEntity obj) => obj.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IEntity obj, IEntity value) => obj.SetValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetAttackDelay(this IEntity obj) => obj.GetValue<IValue<float>>(AttackDelay);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackDelay(this IEntity obj, out IValue<float> value) => obj.TryGetValue(AttackDelay, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackDelay(this IEntity obj, IValue<float> value) => obj.AddValue(AttackDelay, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackDelay(this IEntity obj) => obj.HasValue(AttackDelay);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackDelay(this IEntity obj) => obj.DelValue(AttackDelay);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackDelay(this IEntity obj, IValue<float> value) => obj.SetValue(AttackDelay, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetAttackEvent(this IEntity obj) => obj.GetValue<IEvent>(AttackEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackEvent(this IEntity obj, out IEvent value) => obj.TryGetValue(AttackEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackEvent(this IEntity obj, IEvent value) => obj.AddValue(AttackEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackEvent(this IEntity obj) => obj.HasValue(AttackEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackEvent(this IEntity obj) => obj.DelValue(AttackEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackEvent(this IEntity obj, IEvent value) => obj.SetValue(AttackEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetAttackAction(this IEntity obj) => obj.GetValue<IAction>(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackAction(this IEntity obj, out IAction value) => obj.TryGetValue(AttackAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackAction(this IEntity obj, IAction value) => obj.AddValue(AttackAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackAction(this IEntity obj) => obj.HasValue(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackAction(this IEntity obj) => obj.DelValue(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackAction(this IEntity obj, IAction value) => obj.SetValue(AttackAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IFunction<bool> GetAttackCondition(this IEntity obj) => obj.GetValue<IFunction<bool>>(AttackCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackCondition(this IEntity obj, out IFunction<bool> value) => obj.TryGetValue(AttackCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackCondition(this IEntity obj, IFunction<bool> value) => obj.AddValue(AttackCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackCondition(this IEntity obj) => obj.HasValue(AttackCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackCondition(this IEntity obj) => obj.DelValue(AttackCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackCondition(this IEntity obj, IFunction<bool> value) => obj.SetValue(AttackCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<IEntity> GetInteractAction(this IEntity obj) => obj.GetValue<IAction<IEntity>>(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractAction(this IEntity obj, out IAction<IEntity> value) => obj.TryGetValue(InteractAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractAction(this IEntity obj, IAction<IEntity> value) => obj.AddValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractAction(this IEntity obj) => obj.HasValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractAction(this IEntity obj) => obj.DelValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractAction(this IEntity obj, IAction<IEntity> value) => obj.SetValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static CollisionEventReceiver GetCollision(this IEntity obj) => obj.GetValue<CollisionEventReceiver>(Collision);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCollision(this IEntity obj, out CollisionEventReceiver value) => obj.TryGetValue(Collision, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCollision(this IEntity obj, CollisionEventReceiver value) => obj.AddValue(Collision, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCollision(this IEntity obj) => obj.HasValue(Collision);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCollision(this IEntity obj) => obj.DelValue(Collision);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCollision(this IEntity obj, CollisionEventReceiver value) => obj.SetValue(Collision, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEventReceiver GetTrigger(this IEntity obj) => obj.GetValue<TriggerEventReceiver>(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrigger(this IEntity obj, out TriggerEventReceiver value) => obj.TryGetValue(Trigger, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTrigger(this IEntity obj, TriggerEventReceiver value) => obj.AddValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrigger(this IEntity obj) => obj.HasValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrigger(this IEntity obj) => obj.DelValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrigger(this IEntity obj, TriggerEventReceiver value) => obj.SetValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IEntity obj) => obj.GetValue<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IEntity obj, out Animator value) => obj.TryGetValue(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAnimator(this IEntity obj, Animator value) => obj.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IEntity obj) => obj.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IEntity obj) => obj.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IEntity obj, Animator value) => obj.SetValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AnimationEventReceiver GetAnimationEventReceiver(this IEntity obj) => obj.GetValue<AnimationEventReceiver>(AnimationEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimationEventReceiver(this IEntity obj, out AnimationEventReceiver value) => obj.TryGetValue(AnimationEventReceiver, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAnimationEventReceiver(this IEntity obj, AnimationEventReceiver value) => obj.AddValue(AnimationEventReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimationEventReceiver(this IEntity obj) => obj.HasValue(AnimationEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimationEventReceiver(this IEntity obj) => obj.DelValue(AnimationEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimationEventReceiver(this IEntity obj, AnimationEventReceiver value) => obj.SetValue(AnimationEventReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AudioSource GetAudioSource(this IEntity obj) => obj.GetValue<AudioSource>(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAudioSource(this IEntity obj, out AudioSource value) => obj.TryGetValue(AudioSource, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAudioSource(this IEntity obj, AudioSource value) => obj.AddValue(AudioSource, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAudioSource(this IEntity obj) => obj.HasValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAudioSource(this IEntity obj) => obj.DelValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAudioSource(this IEntity obj, AudioSource value) => obj.SetValue(AudioSource, value);
    }
}
