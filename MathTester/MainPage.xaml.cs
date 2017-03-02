using MathTester.Models;
using MathTester.Pages;
using Windows.UI.Xaml.Controls;

namespace MathTester
{
    public partial class MainPage : Page
    {
        public GameModel gameModel = GameModel.Instance;

        public MainPage()
        {
            this.InitializeComponent();
            SetFrameContent(new StartPage(gameModel));
            Navigator.Instance.MainPage = this;
        }

        public void SetFrameContent(Page page)
        {
            FrmMain.Content = page;
        }

        public Frame GetFrame()
        {
            return FrmMain;
        }
    }
}
