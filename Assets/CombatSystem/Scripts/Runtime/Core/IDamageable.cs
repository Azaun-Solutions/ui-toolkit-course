using System;

namespace CombatSystem.Core
{
    public interface IDamageable
    {
        int health { get; }
        int maxHealth { get; }
        event Action healthChanged;
        event Action maxHealthChanged;
    }
}