using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Practise1
{
    /// Упражнение №4
    public sealed class HealthComponent : MonoBehaviour
    {
        [field: SerializeField]
        public int Health { get; private set; }

        [field: SerializeField]
        public int MaxHealth { get; private set; }

        public event Action<int, int> OnHealthChanged;

        public void TakeDamage(int damage)
        {
            if (this.Health == 0)
                return;

            this.Health = Math.Max(0, this.Health - damage);
        }
    }
    
    public sealed class HealthUI : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text healthText;
    
        [SerializeField]
        private Image healthProgress;

        [SerializeField]
        private HealthComponent healthComponent;
        
        private void Start()
        {
            this.healthText.text = $"Health: {healthComponent.Health}";
            this.healthProgress.fillAmount = (float) healthComponent.Health / healthComponent.MaxHealth;
            healthComponent.OnHealthChanged += AnimateColor;
        }

        private void AnimateColor(int currentHealth, int maxHealth)
        {
            StartCoroutine(AnimateColorCoroutine());
        }

        private IEnumerator AnimateColorCoroutine()
        {
            healthProgress.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            healthProgress.color = Color.green;
        }
    }
}