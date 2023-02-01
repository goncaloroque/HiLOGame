using HILOGame.Repositories;
using HILOGame.Repositories.Interfaces;
using HILOGame.Services;
using HILOGame.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HiLOGame.Startup
{
    public static class Injections
    {
        public static IServiceCollection InjectServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IGameService, GameService>();
            serviceCollection.AddSingleton<IPlayerService, PlayerService>();
            serviceCollection.AddSingleton<IStatisticService, StatisticService>();

            return serviceCollection;
        }

        public static IServiceCollection InjectRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IGameRepository, GameRepository>();
            serviceCollection.AddSingleton<IPlayerRepository, PlayerRepository>();

            return serviceCollection;
        }
    }
}

