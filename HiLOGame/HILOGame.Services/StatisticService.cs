
using AutoMapper;
using HILOGame.Repositories.Interfaces;
using HILOGame.Repositories.Models;
using HILOGame.Services.Interfaces;
using HILOGame.Services.Models;
using HILOGame.Settings;

namespace HILOGame.Services
{
    /// <summary>
    /// Class for generating game statistics
    /// </summary>
    public class StatisticService : IStatisticService
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;

        public StatisticService(IMapper mapper,
            IGameRepository gameRepository)
        {

            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        /// <summary>
        /// Gets games statistics by IS
        /// </summary>
        /// <param name="gameId">The ID of the game</param>
        /// <returns>The game statistics for the specified game ID or null if no game was found</returns>
        public GameStats GetGameStats(Guid gameId)
        {
            var gameModel = _gameRepository.GetGameByID(gameId);
            
            if (gameModel == null)
                return null;

            var gameStats = _mapper.Map<GameStats>(gameModel);

            AddGameStats(gameStats, gameModel);

            return gameStats;
        }

        /// <summary>
        /// Build game statistics
        /// </summary>
        /// <param name="gameStats">The game statistics object that will hold the stats</param>
        /// <param name="game">The game from where the statistic will be retrieved</param>
        private void AddGameStats(GameStats gameStats, GameModel game)
        {
            int totalGames = 0;

            foreach (var player in gameStats.GameStatsPlayers)
            { 
                player.Wins = game.Attempts.Count(attempt=> attempt.PlayerID.CompareTo(player.PlayerID) == 0 && attempt.Result == AttemptResult.WIN);
                totalGames += player.Wins;
            }
            gameStats.TotalGames = totalGames;
        }
    }
}
