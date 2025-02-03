// using System;
// using System.Collections.Generic;
// using Game.Interfaces;
// using UnityEngine;
//
// namespace Game
// {
//     public class DamageTriggerComponent : MonoBehaviour
//     {
//         public event Action<GameObject> OnDamageTriggered;
//
//         [SerializeField] private List<MonoBehaviour> _eventListeners;
//
//         private readonly List<IEventListener> _listeners = new();
//
//         private void Awake()
//         {
//             foreach (var monoBehaviour in _eventListeners)
//             {
//                 if (monoBehaviour is IEventListener eventListener)
//                     _listeners.Add(eventListener);
//             }
//         }
//
//         private void OnEnable()
//         {
//             foreach (var listener in _listeners)
//             {
//                 listener.OnEventTriggered += HandleEvent;
//             }
//         }
//
//         private void OnDisable()
//         {
//             foreach (var listener in _listeners)
//             {
//                 listener.OnEventTriggered -= HandleEvent;
//             }
//         }
//
//         private void HandleEvent(GameObject other)
//         {
//             OnDamageTriggered?.Invoke(other);
//         }
//     }
// }