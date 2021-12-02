namespace CleanCodeTestning.Controllers
{
    public interface IGame
    {
        string FilePath { get; }
        string GetInstructions();
        string Output();
        bool CheckInput(string s);
        void AddCounter();
    }
}