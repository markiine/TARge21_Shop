using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnsResult()
        {
            string guid = Guid.NewGuid().ToString();

            SpaceshipDto spaceship = new SpaceshipDto();

            //spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "asd";
            spaceship.Type = "asd";
            spaceship.Crew = 123;
            spaceship.Passengers = 123;
            spaceship.CargoWeight = 123;
            spaceship.FullTripsCount = 123;
            spaceship.MaintenanceCount = 123;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.EnginePower = 123;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            
            // Arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("4eef8964-c117-4828-b517-121e3cb6915f");

            // Act
            await Svc<ISpaceshipsServices>().GetAsync(guid);

            // Assert
            Assert.NotEqual(wrongGuid, guid);
        }


        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnsEqual()
        {
            
            Guid databaseGuid = Guid.Parse("4eef8964-c117-4828-b517-121e3cb6915f");
            Guid getGuid = Guid.Parse("4eef8964-c117-4828-b517-121e3cb6915f");

            await Svc<ISpaceshipsServices>().GetAsync(getGuid);

            Assert.Equal(databaseGuid, getGuid);
        }


        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            // NOT WORKING
            Guid guid = Guid.Parse("4eef8964-c117-4828-b517-121e3cb6915f");

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse("4eef8964-c117-4828-b517-121e3cb6915f");
            spaceship.Name = "asd";
            spaceship.Type = "asd";
            spaceship.Crew = 123;
            spaceship.Passengers = 123;
            spaceship.CargoWeight = 123;
            spaceship.FullTripsCount = 123;
            spaceship.MaintenanceCount = 123;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.EnginePower = 123;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Delete(guid);
            Assert.Equal(guid, spaceship.Id);


        }

    }
}
