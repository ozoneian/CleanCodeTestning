namespace CleanCodeTestning.Controllers
{
    public interface IGameFactory
    {
        IGame CreateGame(string name);
    }
}