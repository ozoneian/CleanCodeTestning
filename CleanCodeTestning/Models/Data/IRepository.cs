using System.Collections.Generic;

namespace CleanCodeTestning
{
    public interface IRepository
    {
        void Save(string filePath, PlayerData playerData);
        List<PlayerData> GetAllPlayerData(string filePath);
    }
}