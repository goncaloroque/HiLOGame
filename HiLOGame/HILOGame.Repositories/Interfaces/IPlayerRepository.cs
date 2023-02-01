using HILOGame.Repositories.Models;

namespace HILOGame.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        PlayerModel AddPlayer(PlayerModel player);

        PlayerModel? GetPlayerByID(Guid id);

        IEnumerable<PlayerModel>? GetPlayers();
    }
}
