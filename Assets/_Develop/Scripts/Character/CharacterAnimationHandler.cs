using System.Threading.Tasks;

namespace _Develop.Scripts.Character
{
    public class CharacterAnimationHandler
    {
        private readonly CharacterAnimation _characterAnimation;
        private bool _canPlayAnim = true;

        public CharacterAnimationHandler(CharacterAnimation characterAnimation)
        {
            _characterAnimation = characterAnimation;
        }

        public void PlayDamageAnimation()
        {
            if (_canPlayAnim)
            {
                _characterAnimation.TakeDamageAnimation();
                _ = DelayAnimationReset();
            }
        }

        private async Task DelayAnimationReset()
        {
            _canPlayAnim = false;
            await Task.Delay(150); // 0.15 секунд
            _canPlayAnim = true;
        }
    }
}
