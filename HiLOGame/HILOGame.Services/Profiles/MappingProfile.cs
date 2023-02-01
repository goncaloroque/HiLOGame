using AutoMapper;
using HILOGame.Services.Models;
using HILOGame.Repositories.Models;

namespace HILOGame.Services.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerModel>();
            CreateMap<PlayerModel, Player>();

            CreateMap<GameModel, Game>();
            CreateMap<Game, GameModel>();

            CreateMap<GameModel, GameStats>()
                .ForMember(d => d.ID, o => o.MapFrom(s => s.ID))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.GameStatsPlayers, o => o.MapFrom(s => s.GamePlayers))
                .ForMember(d => d.TotalGames, o => o.Ignore());

            CreateMap<GamePlayerModel, GameStatsPlayer>()
                .ForMember(d => d.PlayerID, o => o.MapFrom(s => s.PlayerID))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Wins, o => o.Ignore());

            CreateMap<Attempt, AttemptModel>();
            CreateMap<AttemptModel, Attempt>();

            CreateMap<GamePlayer, GamePlayerModel>();
            CreateMap<GamePlayerModel, GamePlayer>();

        }
    }
}
