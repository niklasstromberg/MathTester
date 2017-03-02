using MathTester.Pages;
using Windows.UI.Xaml.Controls;

namespace MathTester
{
    public class Navigator
    {
        private static Navigator _instance = null;
        private MainPage _mainPage;
        private Frame _frame;

        public Navigator()
        { }

        public static Navigator Instance
        {
            get
            {
                return _instance ?? (_instance = new Navigator());
            }
        }

        public MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
            set
            {
                _mainPage = value;
            }
        }

        public Frame Frame
        {
            get
            {
                return _frame;
            }
            set
            {
                _frame = value;
            }
        }

        public void Navigate(string page)
        {
            if (page == "GameModePage")
                MainPage.SetFrameContent(new GameModePage());
            if (page == "MainGamePage")
                MainPage.SetFrameContent(new MainGamePage());
            if (page == "GameOverPage")
                MainPage.SetFrameContent(new GameOverPage());
        }
    }
}
