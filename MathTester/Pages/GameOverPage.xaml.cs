using MathTester.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MathTester.Pages
{
    public sealed partial class GameOverPage : Page
    {
        public GameOverPage()
        {
            this.InitializeComponent();
            tbStatus.Text = $"Well played! Your score was {GameModel.Instance.Score}";
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            CreateRecord();
            Navigator.Instance.Navigate("GameModePage");
        }

        private void CreateRecord()
        {
            var record = new RecordModel
            {
                Name = tbxName.Text,
                Difficulty = GameModel.Instance.Difficulty,
                GameMode = GameModel.Instance.GameMode,
                Score = GameModel.Instance.Score
            };
            if (GameModel.Instance.RecordHandler.IsHighscore(record))
                GameModel.Instance.RecordHandler.InsertHighscore(record);
        }
    }
}
