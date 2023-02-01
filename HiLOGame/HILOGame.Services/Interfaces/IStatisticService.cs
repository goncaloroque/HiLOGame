using HILOGame.Services.Models;

namespace HILOGame.Services.Interfaces
{
    public interface IStatisticService
    {
        GameStats GetGameStats(Guid gameId);
    }
}