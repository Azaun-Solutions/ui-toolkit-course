using UnityEngine;
using UnityEngine.UIElements;

namespace CombatSystem.UI
{
    public class HealthBarUI : HealthUI
    {
        private ProgressBar m_Bar;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_Bar = m_UIDocument.rootVisualElement.Q<ProgressBar>();
            m_Bar.value = (float)m_Damageable.health / m_Damageable.maxHealth;
        }
        protected override void OnMaxHealthChanged()
        {
            m_Bar.value = (float)m_Damageable.health / m_Damageable.maxHealth;
        }

        protected override void OnHealthChanged()
        {
            m_Bar.value = (float)m_Damageable.health / m_Damageable.maxHealth;

            if (m_Damageable.health > 0)
            {
                if (m_UIDocument.rootVisualElement.style.display == DisplayStyle.None)
                {
                    m_UIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
                }
            }
            else
            {
                m_UIDocument.rootVisualElement.style.display = DisplayStyle.None;
            }
        }
    }
}