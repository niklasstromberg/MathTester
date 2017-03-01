using MathTester.Models;
using MathTester.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MathTester
{
    internal static class Navigator
    {
        public static void Navigate(object sender, RoutedEventArgs e, Page page)
        {
            GameModel gameModel = GameModel.Instance;
            var frame = page.Parent as Frame;
            var button = sender as Button;
            if (button.Name == "btnStart")
            {
                frame.Navigate(typeof(GameModePage), gameModel);
            }
            if(button.Name == "btnPlay")
            {
                frame.Navigate(typeof(MainGamePage), gameModel);
            }
        }
    }
}
