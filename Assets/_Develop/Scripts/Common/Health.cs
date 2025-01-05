namespace _Develop.Scripts.Common
{
    public class Health
    {
        public byte CurrentHealth { get; set; }

        private byte _maxHealth;

        public Health(byte maxHealth)
        {
            _maxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }
        
    }
}
