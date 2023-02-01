using AutoMapper;
using HiLOGame.Requests;
using HiLOGame.Responses;
using HILOGame.Services.Models;

namespace HiLOGame.Profiles
{
    /// <summary>
    /// Represents the mapping profile for objects.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Map from PlayerRequest to Player
            CreateMap<PlayerRequest, Player>()
                .ForMember(d => d.ID, o => o.Ignore());

            // Map from Player to PlayerResponse
            CreateMap<Player, PlayerResponse>()
                .ForMember(d => d.ID, o => o.MapFrom(s => s.ID.ToString()));

            // Map from GameRequest to Game
            CreateMap<GameRequest, Game>()
                .ForMember(d => d.ID, o => o.Ignore());

            // Map from Game to GameResponse
            CreateMap<Game, GameResponse>()
                .ForMember(d => d.ID, o => o.MapFrom(s => s.ID.ToString()));

            // Map from GamePlayer to GamePlayerResponse
            CreateMap<GamePlayer, GamePlayerResponse>();

            // Map from GameStats to GameStatsResponse
            CreateMap<GameStats, GameStatsResponse>()
                .ForMember(d => d.ID, o => o.MapFrom(s => s.ID.ToString()));

            // Map from GameStatsPlayer to GameStatsPlayerResponse
            CreateMap<GameStatsPlayer, GameStatsPlayerResponse>()
                .ForMember(d => d.PlayerID, o => o.MapFrom(s => s.PlayerID.ToString()));
        }
    }
}