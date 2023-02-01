using Microsoft.VisualStudio.TestTools.UnitTesting;
using HILOGame.Repositories;
using HILOGame.Repositories.Models;

namespace HiLOGame.Repositories.Tests
{
    [TestClass]
    public class PlayerRepositoryTests
    {
        private PlayerRepository _playerRepository = new PlayerRepository();

        [TestMethod]
        public void AddPlayer_works_correctly()
        {
            // Arrange
            var player = new PlayerModel()
            {                
                Name = "player1"
            };

            // Act
            var addedPlayer = _playerRepository.AddPlayer(player);

            // Assert
            Assert.IsNotNull(addedPlayer);
            Assert.IsNotNull(addedPlayer.ID);
            Assert.AreEqual(player.Name, addedPlayer.Name);
        }

        [TestMethod]
        public void GetPlayerByID_works_correctly()
        {
            // Arrange
            var player = new PlayerModel()
            {
                Name = "player1"
            };
            var addedPlayer = _playerRepository.AddPlayer(player);

            // Act
            var retrievedPlayer = _playerRepository.GetPlayerByID(addedPlayer.ID);

            // Assert
            Assert.IsNotNull(retrievedPlayer);
            Assert.AreEqual(retrievedPlayer.ID.ToString(), retrievedPlayer.ID.ToString());
            Assert.AreEqual(retrievedPlayer.Name.ToString(), retrievedPlayer.Name.ToString());
        }

        [TestMethod]
        public void GetPlayerByID_player_not_found()
        {
            // Arrange
            var player = new PlayerModel()
            {
                Name = "player1"
            };
            _playerRepository.AddPlayer(player);

            // Act
            var retrievedPlayer = _playerRepository.GetPlayerByID(Guid.NewGuid());

            // Assert
            Assert.IsNull(retrievedPlayer);
        }

        [TestMethod]
        public void GetPlayers_works_correctly()
        {
            // Arrange
            var player = new PlayerModel()
            {
                Name = "player1"
            };
            var player2 = new PlayerModel()
            {
                Name = "player1"
            };

            var addedPlayer = _playerRepository.AddPlayer(player);
            var addedPlayer2 = _playerRepository.AddPlayer(player2);

            // Act
            var retrievedPlayers = _playerRepository.GetPlayers();

            // Assert
            Assert.IsNotNull(retrievedPlayers);
            Assert.AreEqual(2, retrievedPlayers.Count());
            Assert.AreEqual(addedPlayer.ID.ToString(), retrievedPlayers.First().ID.ToString());
            Assert.AreEqual(addedPlayer2.ID.ToString(), retrievedPlayers.Last().ID.ToString());
        }
    }
}