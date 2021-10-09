using System;
using CombatSystem.Core;
using UnityEngine;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private int m_Health = 5;
        [SerializeField] private int m_MaxHealth = 5;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                health--;
            }
        }

        public int health
        {
            get => m_Health;
            set
            {
                m_Health = Mathf.Clamp(value, 0, maxHealth);
                healthChanged?.Invoke();
            }
        }

        public int maxHealth
        {
            get => m_MaxHealth;
            set
            {
                m_MaxHealth = value;
                maxHealthChanged?.Invoke();
            }
        }
        public event Action healthChanged;
        public event Action maxHealthChanged;
    }
}