using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts
{
    public class PlayAudioComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _sourceClip;
        [SerializeField] private MonoBehaviour _component;

        private ITriggerable _trigger;

        private void Awake()
        {
            _trigger = _component as ITriggerable;
        }

        [Button]
        private void Test()
        {
            if (_component is null || _audioSource is null)
                Debug.LogError($"Component or AudioSource are empty");
            else if (_component is not ITriggerable)
                Debug.LogError($"Component does not implement IAudio interface");
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
            _audioSource.PlayOneShot(_sourceClip);
        }
    }
}