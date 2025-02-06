// using Atomic.Elements;
// using Atomic.Entities;
// using Modules.Gameplay;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public class InteractVisualBehaviour : IEntityInit, IEntityDispose
//     {
//         private IEvent _event;
//         private readonly ParticleSystem _vfx;
//         private readonly AudioSource _audioSource;
//         private readonly GameObject _visual;
//         private GameContext _context;
//
//         public InteractVisualBehaviour(ParticleSystem vfx, AudioSource audioSource, GameObject visual)
//         {
//             _vfx = vfx;
//             _audioSource = audioSource;
//             _visual = visual;
//         }
//
//         public void Init(in IEntity entity)
//         {
//             _context = GameContext.Instance;
//             _event = _context.GetCharacter().GetInteractEvent();
//             _event.Subscribe(OnInteracted);
//         }
//
//         public void Dispose(in IEntity entity)
//         {
//             _event.Unsubscribe(OnInteracted);
//         }
//
//         private void OnInteracted()
//         {
//             _vfx.Play();
//             _audioSource.Play();
//             _visual.SetActive(false);
//         }
//     }
// }