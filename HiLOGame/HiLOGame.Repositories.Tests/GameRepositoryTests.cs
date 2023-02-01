using Microsoft.VisualStudio.TestTools.UnitTesting;
using HILOGame.Repositories;
using HILOGame.Repositories.Models;
using HILOGame.Settings;

namespace HiLOGame.Repositories.Tests
{
    [TestClass]
    public class GameRepositoryTests
    {
        private GameRepository _gameRepository = new GameRepository();

        [TestMethod]
        public void AddGame_works_correctly()
        {
            // Arrange
            var game = new GameModel()
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 50,
                MisteryNumber = 25
            };

            // Act
            var addedGame = _gameRepository.AddGame(game);

            // Assert
            Assert.IsNotNull(addedGame);
            Assert.IsNotNull(addedGame.ID);
            Assert.IsNotNull(addedGame.Attempts);
            Assert.IsNotNull(addedGame.GamePlayers);
            Assert.AreEqual(1,addedGame.MinValue);
            Assert.AreEqual(50, addedGame.MaxValue);
            Assert.AreEqual(25, addedGame.MisteryNumber);
        }

        [TestMethod]
        public void GetGameByID_works_correctly()
        {
            // Arrange
            var game = new GameModel()
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 50,
                MisteryNumber = 25
            };
            var addedGame = _gameRepository.AddGame(game);

            // Act
            var retrievedGame = _gameRepository.GetGameByID(addedGame.ID);

            // Assert
            Assert.IsNotNull(retrievedGame);
            Assert.IsNotNull(retrievedGame.ID);
            Assert.IsNotNull(retrievedGame.Attempts);
            Assert.IsNotNull(retrievedGame.GamePlayers);
            Assert.AreEqual(addedGame.ID.ToString(), retrievedGame.ID.ToString());
            Assert.AreEqual(1, retrievedGame.MinValue);
            Assert.AreEqual(50, retrievedGame.MaxValue);
            Assert.AreEqual(25, retrievedGame.MisteryNumber);
        }

        [TestMethod]
        public void GetGameByID_game_not_found()
        {
            // Arrange
            var game = new GameModel()
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 50,
                MisteryNumber = 25
            };
            var addedGame = _gameRepository.AddGame(game);

            // Act
            var retrievedGame = _gameRepository.GetGameByID(Guid.NewGuid());

            // Assert
            Assert.IsNull(retrievedGame);
        }

        [TestMethod]
        public void AddPlayer_works_correctly()
        {
            // Arrange
            var game = new GameModel()
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 50,
                MisteryNumber = 25
            };

            var gamePlayer = new GamePlayerModel()
            {
                PlayerID = Guid.NewGuid(),
                Name = "test player"
            };

            var addedGame = _gameRepository.AddGame(game);

            // Act
            var retrievedGame = _gameRepository.AddPlayer(addedGame.ID, gamePlayer);

            // Assert
            Assert.IsNotNull(retrievedGame);
            Assert.IsNotNull(retrievedGame.GamePlayers);
            Assert.AreEqual(retrievedGame.GamePlayers.First().PlayerID.ToString(), gamePlayer.PlayerID.ToString());
            Assert.AreEqual(retrievedGame.GamePlayers.First().Name, gamePlayer.Name);
        }

        [TestMethod]
        public void AddPlayer_game_not_found()
        {
            // Arrange
            var game = new GameModel()
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 50,
                MisteryNumber = 25
            };

            var gamePlayer = new GamePlayerModel()
            {
                PlayerID = Guid.NewGuid(),
                Name = "test player"
            };

            _gameRepository.AddGame(game);

            // Act
            var retrievedGame = _gameRepository.AddPlayer(Guid.NewGuid(), gamePlayer);

            // Assert
            Assert.IsNull(retrievedGame);
        }

        [TestMethod]
        public void GetPlayers_works_correctly()
        {
            // Arrange
            var game = new GameModel()
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 50,
                MisteryNumber = 25
            };

            var gamePlayer = new GamePlayerModel()
            {
                PlayerID = Guid.NewGuid(),
                Name = "test player"
            };

            var addedGame = _gameRepository.AddGame(game);
            _gameRepository.AddPlayer(addedGame.ID, gamePlayer);

            // Act
            var retrievedPlayers = _gameRepository.GetPlayers(addedGame.ID);

            // Assert
            Assert.IsNotNull(retrievedPlayers);
            Assert.AreEqual(retrievedPlayers.First().PlayerID.ToString(), gamePlayer.PlayerID.ToString());
            Assert.AreEqual(retrievedPlayers.First().Name, gamePlayer.Name);
        }

        [TestMethod]
        public void GetPlayers_game_not_found()
        {
            // Arrange
            var game = new GameModel()
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 50,
                MisteryNumber = 25
            };

            var gamePlayer = new GamePlayerModel()
            {
                PlayerID = Guid.NewGuid(),
                Name = "test player"
            };

            _gameRepository.AddGame(game);
            _gameRepository.AddPlayer(Guid.NewGuid(), gamePlayer);

            // Act
            var retrievedPlayers = _gameRepository.GetPlayers(Guid.NewGuid());

            // Assert
            Assert.IsNull(retrievedPlayers);
        }

        [TestMethod]
        public void RegisterAttempt_works_correctly()
        {
            // Arrange
            var game = new GameModel()
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 50,
                MisteryNumber = 25
            };

            var gameAttempt = new AttemptModel()
            {
                PlayerID = Guid.NewGuid(),
                Value = 10,
                Result= AttemptResult.HI
            };

            var addedGame = _gameRepository.AddGame(game);

            // Act
            var retrievedGame = _gameRepository.RegisterAttempt(addedGame.ID, gameAttempt);

            // Assert
            Assert.IsNotNull(retrievedGame);
            Assert.AreEqual(1, retrievedGame.Attempts.Count);
            Assert.AreEqual(retrievedGame.Attempts.First().PlayerID.ToString(), gameAttempt.PlayerID.ToString());
            Assert.AreEqual(retrievedGame.Attempts.First().Value, gameAttempt.Value);
            Assert.AreEqual(retrievedGame.Attempts.First().Result, gameAttempt.Result);
        }

        [TestMethod]
        public void RegisterAttempt_game_not_found()
        {
            // Arrange
            var game = new GameModel()
            {
                Description = "Test Game",
                MinValue = 1,
                MaxValue = 50,
                MisteryNumber = 25
            };

            var gameAttempt = new AttemptModel()
            {
                PlayerID = Guid.NewGuid(),
                Value = 10,
                Result = AttemptResult.HI
            };

            _gameRepository.AddGame(game);

            // Act
            var retrievedGame = _gameRepository.RegisterAttempt(Guid.NewGuid(), gameAttempt);

            // Assert
            Assert.IsNull(retrievedGame);
        }

    }
}