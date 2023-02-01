using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using HILOGame.Services.Profiles;
using HILOGame.Services.Models;
using HILOGame.Repositories.Models;

namespace HiLOGame.Services.Tests.Profiles
{
    [TestClass]
    public class MappingTests
    {
        [TestMethod]
        public void AutoMapper_Configuration_IsValid()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(typeof(MappingProfile).Assembly));

            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void Player_PlayerModel_TypeCorrect()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(typeof(MappingProfile).Assembly));

            var player = new Player()
            {
                Name = "Test Player",
                ID = Guid.NewGuid()
            };

            var mapped = new Mapper(configuration).Map<PlayerModel>(player);

            Assert.IsNotNull(mapped.ID);
            Assert.AreEqual(player.ID, mapped.ID);
        }

        [TestMethod]
        public void PlayerModel_Player_TypeCorrect()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(typeof(MappingProfile).Assembly));

            var playerModel = new PlayerModel()
            {
                Name = "Test Player",
                ID = Guid.NewGuid()
            };

            var mapped = new Mapper(configuration).Map<Player>(playerModel);

            Assert.IsNotNull(mapped.ID);
            Assert.AreEqual(playerModel.ID, mapped.ID);
        }
    }
}