using MathTester.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace MathTester.Models
{
    public class GameModel : INotifyPropertyChanged
    {
        private static GameModel _instance = null;

        private int _score = 0;
        private int _lives;
        private int _counter;
        private string _player = "";
        private GameMode _mode;
        private IGameModel _gameModeModel = null;
        private Difficulty _difficulty;
        private Frame _frame;
        public Dictionary<string, int> _highscoreStandardEasy = new Dictionary<string, int>();

        public event PropertyChangedEventHandler PropertyChanged;

        public GameModel()
        {
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static GameModel Instance
        {
            get
            {
                return _instance ?? (_instance = new GameModel());
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

        public GameMode GameMode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
            }
        }

        public Difficulty Difficulty
        {
            get
            {
                return _difficulty;
            }
            set
            {
                _difficulty = value;
            }
        }

        public IGameModel GameModeModel
        {
            get
            {
                return _gameModeModel;
            }
            set
            {
                _gameModeModel = value;
            }
        }

        public string Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
            }
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
                OnPropertyChanged("Counter");
            }
        }

        public void SetCounter(int value)
        {
            Counter = value;
        }

        public int Lives
        {
            get
            {
                return _lives;
            }
            set
            {
                _lives = value;
                OnPropertyChanged("Lives");
            }
        }

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnPropertyChanged("Score");
            }
        }

        public void SetDifficulty(string difficulty)
        {
            switch (difficulty)
            {
                case "Easy":
                    {
                        Difficulty = Difficulty.Easy;
                        break;
                    }
                case "Medium":
                    {
                        Difficulty = Difficulty.Medium;
                        break;
                    }
                case "Hard":
                    {
                        Difficulty = Difficulty.Hard;
                        break;
                    }
                default:
                    {
                        Difficulty = Difficulty.None;
                        break;
                    }
            }
        }

        public void SetGameMode(string mode)
        {
            switch (mode)
            {
                case "Standard":
                    {
                        GameModeModel = new StandardGameModel();
                        _instance.GameMode = GameMode.Standard;
                        _instance.Lives = 3;
                        break;
                    }
                case "Marathon":
                    {
                        GameModeModel = new MarathonGameModel();
                        _instance.GameMode = GameMode.Marathon;
                        break;
                    }
                default:
                    {
                        GameModeModel = null;
                        _instance.GameMode = GameMode.None;
                        break;
                    }
            }
        }


    }
}
