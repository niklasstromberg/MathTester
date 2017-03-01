namespace MathTester.Models
{
    public class StandardGameModel : IGameModel
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            return a / b;
        }

        public bool Evaluate(int a, int b)
        {
            return a == b;
        }

        public int Update(bool success)
        {
            if (success)
                return 1;
            return -1;
        }

        public bool GameOver()
        {
            return GameModel.Instance.Lives <= 0;
        }
    }
}
