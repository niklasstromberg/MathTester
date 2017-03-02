using MathTester.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MathTester.Pages
{
    public sealed partial class MainGamePage : Page
    {
        private GameEngine _engine;
        private GameModel _gameModel = GameModel.Instance;
        private IGameModel _gameMode;
        private bool running = false;

        public MainGamePage()
        {
            this.InitializeComponent();
            _engine = new GameEngine();
            _gameMode = _gameModel.GameModeModel;
            Loaded += MainGamePageLoaded;
            this.DataContext = _gameModel;
        }

        void MainGamePageLoaded(object sender, RoutedEventArgs e)
        {
            running = true;
            if (running)
            {
                _engine.StartGame();
                UpdateGUI();
                GameOver();
            }
        }

        private void GameOver()
        {
            if (_gameMode.GameOver())
                running = false;
        }

        private void UpdateGUI()
        {
            tbDifficulty.Text = _gameModel.Difficulty.ToString();
            tbMode.Text = _gameModel.GameMode.ToString();
            tbQuestion.Text = _engine.QuestionString;
            tbxAnswer.Text = "";
        }

        private void btnEvaluateAnswer_Click(object sender, RoutedEventArgs e)
        {
            bool success = _gameMode.Evaluate(_engine.ValueToCompare, GetValue(tbxAnswer.Text));
            Update(success);
            _engine.RestartCycle();
            UpdateGUI();        
        }

        private void Update(bool update)
        {
            int change = _gameMode.Update(update);

            if (_gameModel.GameMode == Enums.GameMode.Standard)
                if (update)
                    _gameModel.Score += change;
                else
                    _gameModel.Lives += change;
            else if (_gameModel.GameMode == Enums.GameMode.Marathon)
                _gameModel.Score += change;
        }

        private int GetValue(string str)
        {
            int result;
            Int32.TryParse(str, out result);
            return result;
        }
    }
}
