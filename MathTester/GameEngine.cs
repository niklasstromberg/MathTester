using MathTester.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace MathTester
{
    internal class GameEngine
    {
        private int a;
        private int b;
        public string QuestionString { get; set; }
        public int ValueToCompare { get; set; }
        private Dictionary<int, string> _operations = new Dictionary<int, string>();
        private string _operation;
        Random random = new Random();
        private int _counter;
        private Timer _timer;

        public GameEngine()
        {
            FillDictionary();
            _counter = GetCounter();
            GameModel.Instance.Counter = _counter;
        }

        public int Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                _counter = value;
                GameModel.Instance.Counter = _counter;
            }
        }

        private int GetCounter()
        {
            return (int)GameModel.Instance.Difficulty;
        }

        private void FillDictionary()
        {
            _operations.Add(1, "+");
            _operations.Add(2, "-");
            _operations.Add(3, "*");
            _operations.Add(4, @"/");
        }

        private string GetOperation()
        {
            Random r = new Random();
            int i = r.Next(1, 4);
            return _operations[i];
        }

        private int GetValueToCompare()
        {
            if (_operation == "+")
                return a + b;
            if (_operation == "-")
                return a - b;
            if (_operation == "*")
                return a * b;
            if (_operation == @"/")
                return a / b;
            return 0;
        }

        private int GenerateNumber()
        {
            return random.Next(1, 10);
        }

        private string GenerateString()
        {
            return a + _operation + b;
        }

        public void StartGame()
        {
            Cycle();
        }

        private void Cycle()
        {
            a = GenerateNumber();
            b = GenerateNumber();
            _operation = GetOperation();
            QuestionString = GenerateString();
            ValueToCompare = GetValueToCompare();
            _timer = new Timer(x => OnCallBack(), null, 0, 0);
        }

        private void OnCallBack()
        {
            _timer.Change(1000, Timeout.Infinite);
            Counter--;
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
    () =>
    {
        GameModel.Instance.SetCounter(_counter);
    });
            //GameModel.Instance.SetCounter(_counter);
            if (CheckTime())
                _timer.Dispose();
        }

        private bool CheckTime()
        {
            return Counter > 0;
        }
    }
}
