using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public class PlayParticleComponent : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particleSource;

        [SerializeField]
        private MonoBehaviour _component;

        private ITriggerable _trigger;

        private void Awake()
        {
            _trigger = _component as ITriggerable;
        }

        [Button]
        private void Test()
        {
            if (_component is null || _particleSource is null)
                Debug.LogError($"Component or ParticleSystem are empty");
            else if (_component is not ITriggerable)
                Debug.LogError($"Component does not implement IVfx interface");
            else
                Play();
        }

        private void OnEnable()
        {
            if (_trigger != null)
            {
                _trigger.OnStateChanged += Play;
            }
        }

        private void OnDisable()
        {
            if (_trigger != null)
            {
                _trigger.OnStateChanged -= Play;
            }
        }

        private void Play()
        {
            _particleSource.Stop();
            _particleSource.Play();
        }
    }
}