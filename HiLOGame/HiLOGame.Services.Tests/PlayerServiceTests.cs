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
    public class PlayerServiceTests
    {
        [TestMethod]
        public void AddPlayer_works_correctly()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            var player = new Player { Name = "Test Player" };
            var playerModel = new PlayerModel { Name = player.Name };

            mockMapper.Setup(x => x.Map<PlayerModel>(player))
                      .Returns(playerModel);
            mockMapper.Setup(x => x.Map<Player>(playerModel))
                      .Returns(player);
            mockPlayerRepository.Setup(x => x.AddPlayer(playerModel))
                                .Returns(playerModel);

            var playerService = new PlayerService(mockMapper.Object,
                                                  mockPlayerRepository.Object);

            // Act
            var addedPlayer = playerService.AddPlayer(player);

            // Assert
            mockMapper.Verify(x => x.Map<PlayerModel>(player), Times.Once);
            mockMapper.Verify(x => x.Map<Player>(playerModel), Times.Once);
            mockPlayerRepository.Verify(x => x.AddPlayer(playerModel), Times.Once);
            Assert.AreEqual(player.ID.ToString(), addedPlayer.ID.ToString());
            Assert.AreEqual(player.Name, addedPlayer.Name);
        }

        [TestMethod]
        public void GetPlayerByID_works_correctly()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            var player = new Player { Name = "Test Player" };
            var playerModel = new PlayerModel { Name = player.Name };
            var id = Guid.NewGuid();

            mockMapper.Setup(x => x.Map<Player>(playerModel))
                      .Returns(player);
            mockPlayerRepository.Setup(x => x.GetPlayerByID(id))
                                .Returns(playerModel);

            var playerService = new PlayerService(mockMapper.Object,
                                                  mockPlayerRepository.Object);

            // Act
            var result = playerService.GetPlayerByID(id);

            // Assert
            mockMapper.Verify(x => x.Map<Player>(playerModel), Times.Once);
            mockPlayerRepository.Verify(x => x.GetPlayerByID(id), Times.Once);
            Assert.AreEqual(player.ID.ToString(), result.ID.ToString());
            Assert.AreEqual(player.Name, result.Name);
        }

        [TestMethod]
        public void GetPlayerByID_player_not_found()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            var player = new Player { Name = "Test Player" };
            var playerModel = new PlayerModel { Name = player.Name };
            var id = Guid.NewGuid();

            mockMapper.Setup(x => x.Map<Player>(playerModel))
                      .Returns(player);

            mockPlayerRepository.Setup(x => x.GetPlayerByID(id))
                                .Returns(playerModel);

            var playerService = new PlayerService(mockMapper.Object,
                                                  mockPlayerRepository.Object);

            // Act
            var result = playerService.GetPlayerByID(Guid.NewGuid());

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetPlayers_works_correctly()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockPlayerRepository = new Mock<IPlayerRepository>();

            PlayerModel[] playerModels = new PlayerModel[]
            {
                new PlayerModel { ID = Guid.NewGuid(), Name = "Player 1" },
                new PlayerModel { ID = Guid.NewGuid(), Name = "Player 2" }
            };

            Player[] players = new Player[]
            {
                new Player { ID = playerModels[0].ID, Name = playerModels[0].Name },
                new Player { ID = playerModels[1].ID, Name = playerModels[1].Name }
            };

            mockPlayerRepository.Setup(x => x.GetPlayers()).Returns(playerModels);
            mockMapper.Setup(x => x.Map<Player[]>(playerModels)).Returns(players);

            var playerService = new PlayerService(mockMapper.Object, mockPlayerRepository.Object);

            // Act
            var result = playerService.GetPlayers();

            // Assert
            mockPlayerRepository.Verify(x => x.GetPlayers(), Times.Once);
            mockMapper.Verify(x => x.Map<Player[]>(playerModels), Times.Once);

            Assert.IsNotNull(result);
            Assert.AreEqual(players, result);
        }

    }
}