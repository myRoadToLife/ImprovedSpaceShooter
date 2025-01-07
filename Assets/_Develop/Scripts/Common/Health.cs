namespace _Develop.Scripts.Common
{
    public class Health
    {
        public float CurrentHealth { get; set; }
        public float MaxHealth { get; private set; }


        public Health(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
        }
    }
}
