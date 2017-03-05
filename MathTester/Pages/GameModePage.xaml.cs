using MathTester.Enums;
using MathTester.Models;
using System.Collections.Generic;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MathTester.Pages
{
    public sealed partial class GameModePage : Page
    {
        private GameModel GameModel = GameModel.Instance;
        public GameModePage()
        {
            this.InitializeComponent();
            GameModel.ResetModel();
            ShowHide();
        }

        private void ShowHide()
        {
            if (GameModel.GameMode == GameMode.None)
                spDifficulty.Visibility = Visibility.Collapsed;
            else
                spDifficulty.Visibility = Visibility.Visible;
            if (GameModel.Difficulty == Difficulty.None)
                btnPlay.Visibility = Visibility.Collapsed;
            else
                btnPlay.Visibility = Visibility.Visible;
        }

        private void btnMode_Click(object sender, RoutedEventArgs e)
        {
            GameModel.SetDifficulty("");
            var button = sender as Button;
            var mode = button.Content.ToString();
            GameModel.SetGameMode(mode);
            SetColours(button);
            ShowHide();
        }

        private void btnDif_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var difficulty = button.Content.ToString();
            GameModel.SetDifficulty(difficulty);
            SetColours(button);
            FillHighScore();
            ShowHide();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Instance.Navigate("MainGamePage");
        }

        private void FillHighScore()
        {
            var records = GameModel.RecordHandler.GetTopThree(GameModel.GameMode, GameModel.Difficulty);
            lvHighScore.ItemsSource = records;
        }

        private void SetColours(Button button)
        {
            foreach (var b in FindVisualChildren<Button>(spMainPanel))
            {
                if (b.Name == button.Name)
                    b.Background = new SolidColorBrush(Colors.Green);
                else
                    b.Background = new SolidColorBrush(Colors.LightGray);
            }
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
