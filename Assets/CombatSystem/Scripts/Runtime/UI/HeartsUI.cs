using CombatSystem.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace CombatSystem.UI
{
    public class HeartsUI : HealthUI
    {
        private VisualElement m_Hearts;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_Hearts = m_UIDocument.rootVisualElement.Q("panel");
            OnMaxHealthChanged();
            OnHealthChanged();
        }

        protected override void OnMaxHealthChanged()
        {
            for (int i = 0; i < m_Hearts.childCount; i++)
            {
                if (i < m_Damageable.maxHealth)
                {
                    m_Hearts[i].style.visibility = Visibility.Visible;
                }
                else
                {
                    m_Hearts[i].style.visibility = Visibility.Hidden;
                }
            }
        }

        protected override void OnHealthChanged()
        {
            for (int i = 0; i < m_Hearts.childCount; i++)
            {
                if (i < m_Damageable.health)
                {
                    m_Hearts[i][0].style.visibility = Visibility.Visible;
                }
                else
                {
                    m_Hearts[i][0].style.visibility = Visibility.Hidden;
                }
            }
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            if (m_Owner != null)
            {
                if (m_Owner.GetComponent<IDamageable>().maxHealth > 20)
                {
                    Debug.LogWarning("The maximum health cannot exceed 20!");
                    m_Owner = null;
                }
            }
        }
    }
}