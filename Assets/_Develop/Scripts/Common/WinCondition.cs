using System.Threading.Tasks;

namespace _Develop.Scripts.Common
{
    public class WinCondition
    {
        private readonly EndLevelManager _endLevelManager;

        public WinCondition(EndLevelManager endLevelManager)
        {
            _endLevelManager = endLevelManager;

            _ = HoldOnToWin();
        }


        private async Task HoldOnToWin()
        {
            const int millisecondsDelay = 10000;
            await Task.Delay(millisecondsDelay);

            if (!_endLevelManager.IsGameOver())
            {
                _endLevelManager.SetGameOver(false);
                _ = _endLevelManager.FinishGame();
            }
        }
    }
}
