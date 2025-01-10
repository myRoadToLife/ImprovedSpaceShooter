using UnityEngine;

namespace _Develop.Scripts.Character
{
    public class CharacterStats
    {
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        public CharacterStats(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        }

        public bool IsDead => CurrentHealth <= 0;
    }
}
