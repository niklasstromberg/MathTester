namespace MathTester.Models
{
    public interface IGameModel
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
        bool Evaluate(int a, int b);
        int Update(bool success);
        bool GameOver();
    }
}
