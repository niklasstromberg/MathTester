using MathTester.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;

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
        public DispatcherTimer _dispatcherTimer;

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

        public void SpinUpCycle()
        {
            if (_dispatcherTimer == null)
                _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            _dispatcherTimer.Tick += Dt_Tick;
        }

        public void StartGame()
        {
            SpinUpCycle();
            Cycle();
        }

        public void RestartCycle()
        {
            Cycle();
        }

        public void StopCycle()
        {
            _dispatcherTimer.Stop();
        }

        private void Cycle()
        {
            GameModel.Instance.Counter = GetCounter();
            a = GenerateNumber();
            b = GenerateNumber();
            _operation = GetOperation();
            QuestionString = GenerateString();
            ValueToCompare = GetValueToCompare();
            _dispatcherTimer.Start();
        }

        private void Dt_Tick(object sender, object e)
        {
            GameModel.Instance.Counter--;
            if (CheckTime())
            {
                // fortsätt ticka ner mot noll
            }
            else
            {
                int change = GameModel.Instance.GameModeModel.Update(false);
                if (GameModel.Instance.GameMode == Enums.GameMode.Marathon)
                    GameModel.Instance.Score -= change;
                if (GameModel.Instance.GameMode == Enums.GameMode.Standard)
                    GameModel.Instance.Lives--;
                if (GameModel.Instance.GameModeModel.GameOver())
                {
                    StopCycle();
                    Navigator.Instance.Navigate("GameOverPage");
                }
                Cycle();
            }
        }

        private bool CheckTime()
        {
            return GameModel.Instance.Counter > 0;
        }
    }
}
