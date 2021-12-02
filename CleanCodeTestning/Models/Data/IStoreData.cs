namespace CleanCodeTestning
{
    public interface IStoreData
    {
        void Save(string filePath);
        void GetAllPlayerData(string filePath);
    }
}