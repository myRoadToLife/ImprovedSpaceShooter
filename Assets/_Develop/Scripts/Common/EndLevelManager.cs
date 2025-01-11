using System.Threading.Tasks;
using _Develop.Scripts.UI;

namespace _Develop.Scripts.Common
{
    public class EndLevelManager
    {
        private readonly PanelController _panelController;
        private readonly EnemiesSpawner _enemiesSpawner;
        
        private bool _isGameOver;
        
        public EndLevelManager(PanelController panelController, EnemiesSpawner enemiesSpawner)
        {
            _panelController = panelController;
            _enemiesSpawner = enemiesSpawner;
        }

        public void SetGameOver(bool value) => _isGameOver = value;
        
        public bool IsGameOver() => _isGameOver;

        public async Task FinishGame()
        {
            _enemiesSpawner.gameObject.SetActive(false);

            const int millisecondsDelay = 2500;
            await Task.Delay(millisecondsDelay);

            if (_isGameOver)
                LoseGame();
            else
                WinGame();
        }

        private void WinGame() => _panelController.ShowWinScreen();
        
        private void LoseGame() => _panelController.ShowLoseScreen();
    }
}
