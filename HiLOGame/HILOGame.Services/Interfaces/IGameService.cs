using HILOGame.Repositories.Models;
using HILOGame.Services.Models;
using HILOGame.Settings;

namespace HILOGame.Services.Interfaces
{
    public interface IGameService
    {
        Game CreateGame(Game game);

        Game GetGameByID(Guid id);

        IEnumerable<Game> GetGames();

        Game? JoinGame(Guid gameId, Guid playerId);

        string GameAttempt(Guid gameId, Guid playerId, int value);

    }
}