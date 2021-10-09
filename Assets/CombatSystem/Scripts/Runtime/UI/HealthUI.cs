using CombatSystem.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace CombatSystem.UI
{
    [RequireComponent(typeof(UIDocument))]
    public abstract class HealthUI : MonoBehaviour
    {
        protected UIDocument m_UIDocument;
        [SerializeField] protected GameObject m_Owner;
        protected IDamageable m_Damageable;

        protected void Awake()
        {
            m_UIDocument = GetComponent<UIDocument>();
            m_Damageable = m_Owner.GetComponent<IDamageable>();
        }

        protected virtual void OnEnable()
        {
            m_Damageable.healthChanged += OnHealthChanged;
            m_Damageable.maxHealthChanged += OnMaxHealthChanged;
        }

        protected virtual void OnDisable()
        {
            m_Damageable.healthChanged -= OnHealthChanged;
            m_Damageable.maxHealthChanged -= OnMaxHealthChanged;
        }

        protected abstract void OnMaxHealthChanged();

        protected abstract void OnHealthChanged();

        private void OnValidate()
        {
            if (m_Owner != null)
            {
                if (m_Owner.GetComponent<IDamageable>() == null)
                {
                    Debug.LogWarning("The owner must implement the IDamageable interface!");
                    m_Owner = null;
                }
            }
        }
    }
}