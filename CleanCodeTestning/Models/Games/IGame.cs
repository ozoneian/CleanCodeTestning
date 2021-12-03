namespace CleanCodeTestning.Controllers
{
    public interface IGame
    {
        string FilePath { get; }
        int GuessCount { get; }
        string GetInstructions();
        string Output();
        bool CheckInput(string s);
        void IncrementGuess();
    }
}