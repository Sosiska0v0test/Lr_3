using modified_Lr_3.Entity.GameEntities;

namespace modified_Lr_3.Repository.IRepository;

public interface IGameRepository
{
    void CreateGame(GameEntity game);
    GameEntity ReadGameById(int gameId);
    IEnumerable<GameEntity> ReadAllGames();
}