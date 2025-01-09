using UnityEngine;

namespace _Develop.Scripts.Character
{
    public class CharacterAnimation
    {
        private static readonly int Damage = Animator.StringToHash("Damage");
        private readonly Animator _animator;

        public CharacterAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void TakeDamageAnimation()
        {
            _animator.SetTrigger(Damage);
        }
    }
}
