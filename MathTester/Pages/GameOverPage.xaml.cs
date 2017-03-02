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
            Navigator.Instance.Navigate("GameModePage");
        }
    }
}
