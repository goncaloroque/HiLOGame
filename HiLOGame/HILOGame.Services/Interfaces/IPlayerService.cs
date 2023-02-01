using HILOGame.Services.Models;

namespace HILOGame.Services.Interfaces
{
    public interface IPlayerService
    {
        Player AddPlayer(Player player);

        IEnumerable<Player> GetPlayers();

        Player GetPlayerByID(Guid id);
    }
}