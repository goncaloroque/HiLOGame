using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using HILOGame.Repositories.Interfaces;
using HILOGame.Repositories.Models;
using HILOGame.Services;
using HILOGame.Services.Models;
using Moq;

namespace HiLOGame.Services.Tests
{
    [TestClass]
    public class GameServiceTests
    {
        [TestMethod]
        public void CreateGame_works_correctly()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockGameRepository = new Mock<IGameRepository>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            var game = new Game
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 100,
            };

            var gameModel = new GameModel
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 100,
            };

            mockMapper.Setup(x => x.Map<GameModel>(game))
                      .Returns(gameModel);
            mockMapper.Setup(x => x.Map<Game>(gameModel))
                      .Returns(game);
            mockGameRepository.Setup(x => x.AddGame(gameModel))
                                .Returns(gameModel);

            var gameService = new GameService(mockMapper.Object,
                                                  mockGameRepository.Object,
                                                  mockPlayerRepository.Object);

            // Act
            var addedGame = gameService.CreateGame(game);

            // Assert
            mockMapper.Verify(x => x.Map<GameModel>(game), Times.Once);
            mockMapper.Verify(x => x.Map<Game>(gameModel), Times.Once);
            mockGameRepository.Verify(x => x.AddGame(gameModel), Times.Once);
            Assert.AreEqual(game.ID.ToString(), addedGame.ID.ToString());
            Assert.AreEqual(game.Description, addedGame.Description);
        }

        [TestMethod]
        public void GetGameByID_works_correctly()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockGameRepository = new Mock<IGameRepository>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            var game = new Game
            {
                ID = Guid.NewGuid(),
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 100,
            };

            var gameModel = new GameModel
            {
                ID = game.ID,
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 100,
            };

            mockMapper.Setup(x => x.Map<GameModel>(game))
                      .Returns(gameModel);
            mockMapper.Setup(x => x.Map<Game>(gameModel))
                      .Returns(game);
            mockGameRepository.Setup(x => x.GetGameByID(game.ID))
                                .Returns(gameModel);

            var gameService = new GameService(mockMapper.Object,
                                                  mockGameRepository.Object,
                                                  mockPlayerRepository.Object);
            // Act
            
            var result = gameService.GetGameByID(game.ID);

            // Assert
            mockMapper.Verify(x => x.Map<Game>(gameModel), Times.Once);
            mockGameRepository.Verify(x => x.GetGameByID(game.ID), Times.Once);
            Assert.AreEqual(result.ID.ToString(), game.ID.ToString());
            Assert.AreEqual(result.Description, game.Description);
        }

        [TestMethod]
        public void GetGameByID_game_not_found()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockGameRepository = new Mock<IGameRepository>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            var gameService = new GameService(mockMapper.Object,
                                                  mockGameRepository.Object,
                                                  mockPlayerRepository.Object);
            // Act

            var result = gameService.GetGameByID(Guid.NewGuid());

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetGames_works_correctly()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockGameRepository = new Mock<IGameRepository>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            GameModel[] gameModels = new GameModel[]
            {
                new GameModel { ID = Guid.NewGuid(), Description = "Game 1" },
                new GameModel { ID = Guid.NewGuid(), Description = "Game 2" }
            };

            Game[] games = new Game[]
            {
                new Game { ID = gameModels[0].ID, Description = gameModels[0].Description },
                new Game { ID = gameModels[1].ID, Description = gameModels[1].Description }
            };

            mockGameRepository.Setup(x => x.GetGames()).Returns(gameModels);
            mockMapper.Setup(x => x.Map<Game[]>(gameModels)).Returns(games);

            var gameService = new GameService(mockMapper.Object,
                                                  mockGameRepository.Object,
                                                  mockPlayerRepository.Object);

            // Act
            var result = gameService.GetGames();

            // Assert
            mockGameRepository.Verify(x => x.GetGames(), Times.Once);
            mockMapper.Verify(x => x.Map<Game[]>(gameModels), Times.Once);

            Assert.IsNotNull(result);
            Assert.AreEqual(games, result);
        }

        [TestMethod]
        public void JoinGame_works_correctly()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockGameRepository = new Mock<IGameRepository>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            var game = new Game
            {
                ID = Guid.NewGuid(),
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 100,
            };

            var gameModel = new GameModel
            {
                ID = game.ID,
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 100,
            };

            mockMapper.Setup(x => x.Map<Game>(It.Is<GameModel>(d => d.ID == game.ID)))
                      .Returns(game);

            mockGameRepository.Setup(x => x.GetGameByID(game.ID))
                                .Returns(gameModel);


            var player = new Player { Name = "Test Player" };
            var playerModel = new PlayerModel { Name = player.Name };
            var playerID = Guid.NewGuid();

            mockMapper.Setup(x => x.Map<Player>(playerModel))
                      .Returns(player);

            mockPlayerRepository.Setup(x => x.GetPlayerByID(playerID))
                                .Returns(playerModel);


            var gamePlayerModel = new GamePlayerModel { Name = "Test Player", PlayerID = playerID };
            mockGameRepository.Setup(x => x.AddPlayer(game.ID, It.Is<GamePlayerModel>(d => d.Name == gamePlayerModel.Name)))
                                .Returns(gameModel);

            var gameService = new GameService(mockMapper.Object,
                                                  mockGameRepository.Object,
                                                  mockPlayerRepository.Object);
            // Act

            var result = gameService.JoinGame(game.ID, playerID);

            // Assert
            mockMapper.Verify(x => x.Map<Game>(gameModel), Times.Once);
            mockGameRepository.Verify(x => x.GetGameByID(game.ID), Times.Once);
            Assert.AreEqual(result.ID.ToString(), game.ID.ToString());
            Assert.AreEqual(result.Description, game.Description);
        }

        [TestMethod]
        public void JoinGame_player_not_found()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockGameRepository = new Mock<IGameRepository>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            var game = new Game
            {
                ID = Guid.NewGuid(),
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 100,
            };

            var gameModel = new GameModel
            {
                ID = game.ID,
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 100,
            };

            mockMapper.Setup(x => x.Map<Game>(It.Is<GameModel>(d => d.ID == game.ID)))
                      .Returns(game);

            mockGameRepository.Setup(x => x.GetGameByID(game.ID))
                                .Returns(gameModel);


            var player = new Player { Name = "Test Player" };
            var playerModel = new PlayerModel { Name = player.Name };
            var playerID = Guid.NewGuid();

            mockMapper.Setup(x => x.Map<Player>(playerModel))
                      .Returns(player);

            mockPlayerRepository.Setup(x => x.GetPlayerByID(playerID))
                                .Returns(playerModel);


            var gamePlayerModel = new GamePlayerModel { Name = "Test Player", PlayerID = playerID };
            mockGameRepository.Setup(x => x.AddPlayer(game.ID, It.Is<GamePlayerModel>(d => d.Name == gamePlayerModel.Name)))
                                .Returns(gameModel);

            var gameService = new GameService(mockMapper.Object,
                                                  mockGameRepository.Object,
                                                  mockPlayerRepository.Object);
            // Act

            var result = gameService.JoinGame(game.ID, Guid.NewGuid());

            // Assert
            
            mockPlayerRepository.Verify(x => x.GetPlayerByID(It.IsAny<Guid>()), Times.Once);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void JoinGame_game_not_found()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockGameRepository = new Mock<IGameRepository>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            var game = new Game
            {
                ID = Guid.NewGuid(),
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 100,
            };

            var gameModel = new GameModel
            {
                ID = game.ID,
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 100,
            };

            mockMapper.Setup(x => x.Map<Game>(It.Is<GameModel>(d => d.ID == game.ID)))
                      .Returns(game);

            mockGameRepository.Setup(x => x.GetGameByID(game.ID))
                                .Returns(gameModel);


            var player = new Player { Name = "Test Player" };
            var playerModel = new PlayerModel { Name = player.Name };
            var playerID = Guid.NewGuid();

            mockMapper.Setup(x => x.Map<Player>(playerModel))
                      .Returns(player);

            mockPlayerRepository.Setup(x => x.GetPlayerByID(playerID))
                                .Returns(playerModel);


            var gamePlayerModel = new GamePlayerModel { Name = "Test Player", PlayerID = playerID };
            mockGameRepository.Setup(x => x.AddPlayer(game.ID, It.Is<GamePlayerModel>(d => d.Name == gamePlayerModel.Name)))
                                .Returns(gameModel);

            var gameService = new GameService(mockMapper.Object,
                                                  mockGameRepository.Object,
                                                  mockPlayerRepository.Object);
            // Act

            var result = gameService.JoinGame(Guid.NewGuid(), playerID);

            // Assert
            mockGameRepository.Verify(x => x.GetGameByID(It.IsAny<Guid>()), Times.Once);
            mockPlayerRepository.Verify(x => x.GetPlayerByID(It.IsAny<Guid>()), Times.Once);
            Assert.IsNull(result);
        }

    }
}