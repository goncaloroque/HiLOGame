using HILOGame.Repositories.Models;

namespace HILOGame.Repositories.Interfaces
{
    public interface IGameRepository
    {
        GameModel AddGame(GameModel game);

        GameModel? GetGameByID(Guid gameId);

        IEnumerable<GameModel>? GetGames();

        GameModel? AddPlayer(Guid gameId, GamePlayerModel gamePlayer);

        IEnumerable<GamePlayerModel>? GetPlayers(Guid gameId);

        GameModel? RegisterAttempt(Guid gameId, AttemptModel attempt);
    }
}
