using MathTester.Enums;
using MathTester.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MathTester.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameModePage : Page
    {
        private GameModel GameModel = GameModel.Instance;
        public GameModePage()
        {
            this.InitializeComponent();
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
            button.Background = new SolidColorBrush(Colors.Green);
            ShowHide();
        }

        private void btnDif_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var difficulty = button.Content.ToString();
            GameModel.SetDifficulty(difficulty);
            button.Background = new SolidColorBrush(Colors.Green);
            ShowHide();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate(sender, e, this);
        }
    }
}
