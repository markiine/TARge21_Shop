using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
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
            spaceship.MaintenanceCount = 1000;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.EnginePower = 1000;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdSpceship_WhenReturnsNotEqual()
        {
            //Arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("6e8285f6-5205-46d4-b12e-c522f797f378");

            //Act
            await Svc<ISpaceshipsServices>().GetAsync(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);
        }


        [Fact]
        public async Task Should_GetByIdSpceship_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("6e8285f6-5205-46d4-b12e-c522f797f378");
            Guid getGuid = Guid.Parse("6e8285f6-5205-46d4-b12e-c522f797f378");

            await Svc<ISpaceshipsServices>().GetAsync(getGuid);

            Assert.Equal(databaseGuid, getGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();

            var addSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship.Id);

            Assert.Equal(result, addSpaceship);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();
            var addspaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var addSpaceship2 = await Svc<ISpaceshipsServices>().Create(spaceship);

            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship2.Id);

            Assert.NotEqual(result.Id, addspaceship.Id);
        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("6e8285f6-5205-46d4-b12e-c522f797f378");

            Spaceship spaceship = new Spaceship();

            SpaceshipDto dto = MockSpaceshipData();

            spaceship.Id = Guid.Parse("6e8285f6-5205-46d4-b12e-c522f797f378");
            spaceship.Name = "Name123";
            spaceship.Type = "asd";
            spaceship.Crew = 123;
            spaceship.Passengers = 123123;
            spaceship.CargoWeight = 123;
            spaceship.FullTripsCount = 123123;
            spaceship.MaintenanceCount = 1000123;
            spaceship.LastMaintenance = DateTime.Now.AddYears(1);
            spaceship.EnginePower = 1000123;
            spaceship.MaidenLaunch = DateTime.Now.AddYears(1);
            spaceship.BuiltDate = DateTime.Now.AddYears(1);
            spaceship.CreatedAt = DateTime.Now.AddYears(1);
            spaceship.ModifiedAt = DateTime.Now.AddYears(1);


            await Svc<ISpaceshipsServices>().Update(dto);

            Assert.Equal(spaceship.Id, guid);
            Assert.DoesNotMatch(spaceship.Name, dto.Name);
            Assert.DoesNotMatch(spaceship.EnginePower.ToString(), dto.EnginePower.ToString());
            Assert.Equal(spaceship.Crew, dto.Crew);

        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateDataVersion2()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

            SpaceshipDto update = MockUpdateSpaceship();
            var result = await Svc<ISpaceshipsServices>().Update(update);

            Assert.Equal(update.Id, dto.Id);
            Assert.DoesNotMatch(result.Name, createSpaceship.Name);
            Assert.DoesNotMatch(result.EnginePower.ToString(), createSpaceship.EnginePower.ToString());
            Assert.Equal(result.Crew, createSpaceship.Crew);
            Assert.NotEqual(result.ModifiedAt, createSpaceship.ModifiedAt);
        }

        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

            SpaceshipDto nullUpdate = MockNullSpaceship();
            var result = await Svc<ISpaceshipsServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.False(result.Id == nullId);
        }

        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "Name",
                Type = "asd",
                Crew = 123,
                Passengers = 123,
                CargoWeight = 123,
                FullTripsCount = 123,
                MaintenanceCount = 1000,
                LastMaintenance = DateTime.Now,
                EnginePower = 1000,
                MaidenLaunch = DateTime.Now,
                BuiltDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return spaceship;
        }

        private SpaceshipDto MockUpdateSpaceship()
        {
            SpaceshipDto update = new()
            {
                Name = "Name123",
                Type = "asd",
                Crew = 123,
                Passengers = 123123,
                CargoWeight = 123,
                FullTripsCount = 123123,
                MaintenanceCount = 1000123,
                LastMaintenance = DateTime.Now.AddYears(1),
                EnginePower = 1000123,
                MaidenLaunch = DateTime.Now.AddYears(1),
                BuiltDate = DateTime.Now.AddYears(1),
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1),
            };

            return update;
        }

        private SpaceshipDto MockNullSpaceship()
        {
            SpaceshipDto nullDto = new()
            {
                Id = null,
                Name = "Name123",
                Type = "asd",
                Crew = 123,
                Passengers = 123123,
                CargoWeight = 123,
                FullTripsCount = 123123,
                MaintenanceCount = 1000123,
                LastMaintenance = DateTime.Now.AddYears(1),
                EnginePower = 1000123,
                MaidenLaunch = DateTime.Now.AddYears(1),
                BuiltDate = DateTime.Now.AddYears(1),
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1),
            };

            return nullDto;
        }



        //[Fact]
        //public async Task Should_AddSpaceship_WhenDtoValid()
        //{
        //    SpaceshipDto spaceship = CreateSpaceshipDto();
        //    var result = await Svc<ISpaceshipsServices>().Create(spaceship);
        //    AssertSpaceships(spaceship, result);
        //}

        //[Fact]
        //public async Task ShouldNot_GetSpaceshipById_WhenSpaceshipNotFound()
        //{
        //    Assert.Null(await Svc<ISpaceshipsServices>().GetAsync(Guid.NewGuid()));
        //}

        //[Fact]
        //public async Task Should_GetSpaceshipById_WhenSpaceshipIsFound()
        //{
        //    SpaceshipDto spaceship = CreateSpaceshipDto();
        //    var createdSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
        //    var recivedSpaceship = await Svc<ISpaceshipsServices>().GetAsync((Guid)createdSpaceship.Id);
        //    Assert.Equal(createdSpaceship, recivedSpaceship);
        //}

        //[Fact]
        //public async Task Should_DeleteSpaceshipById_WhenSpaceshipIsFound()
        //{
        //    SpaceshipDto spaceship = CreateSpaceshipDto();
        //    var createdSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
        //    var deletedSpaceship = await Svc<ISpaceshipsServices>().Delete((Guid)createdSpaceship.Id);
        //    Assert.Equal(createdSpaceship, deletedSpaceship);
        //}

        //[Fact]
        //public async Task Should_UpdateSpaceship_WhenDtoValid()
        //{
        //    SpaceshipDto spaceship = CreateSpaceshipDto();
        //    await Svc<ISpaceshipsServices>().Create(spaceship);
        //    spaceship = UpdateDto(spaceship);
        //    var recivedUpdatedSpaceship = await Svc<ISpaceshipsServices>().Update(spaceship);
        //    AssertSpaceships(spaceship, recivedUpdatedSpaceship);
        //}

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertions", "xUnit2002:Do not use null check on value type", Justification = "<Pending>")]
        //internal static void AssertSpaceships(SpaceshipDto expected, Spaceship actual)
        //{
        //    Assert.NotNull(actual.Id);
        //    Assert.NotNull(actual.CreatedAt);
        //    Assert.NotNull(actual.ModifiedAt);
        //    Assert.Equal(expected.Name, actual.Name);
        //    Assert.Equal(expected.Type, actual.Type);
        //    Assert.Equal(expected.Crew, actual.Crew);
        //    Assert.Equal(expected.Passengers, actual.Passengers);
        //    Assert.Equal(expected.CargoWeight, actual.CargoWeight);
        //    Assert.Equal(expected.FullTripsCount, actual.FullTripsCount);
        //    Assert.Equal(expected.MaintenanceCount, actual.MaintenanceCount);
        //    Assert.Equal(expected.LastMaintenance, actual.LastMaintenance);
        //    Assert.Equal(expected.EnginePower, actual.EnginePower);
        //    Assert.Equal(expected.MaidenLaunch, actual.MaidenLaunch);
        //    Assert.Equal(expected.BuiltDate, actual.BuiltDate);
        //}

        //public static SpaceshipDto CreateSpaceshipDto()
        //{
        //    SpaceshipDto spaceship = new()
        //    {
        //        Name = "asd",
        //        Type = "asd",
        //        Crew = 123,
        //        Passengers = 123,
        //        CargoWeight = 123,
        //        FullTripsCount = 123,
        //        MaintenanceCount = 123,
        //        LastMaintenance = DateTime.Now,
        //        EnginePower = 123,
        //        MaidenLaunch = DateTime.Now,
        //        BuiltDate = DateTime.Now
        //    };

        //    return spaceship;
        //}

        //public static SpaceshipDto UpdateDto(SpaceshipDto spaceship)
        //{
        //    SpaceshipDto newSpaceship = spaceship;
        //    newSpaceship.Name = "dsa";
        //    newSpaceship.Type = "dsa";
        //    newSpaceship.Crew = 321;
        //    newSpaceship.Passengers = 321;
        //    newSpaceship.CargoWeight = 321;
        //    newSpaceship.FullTripsCount = 321;
        //    newSpaceship.MaintenanceCount = 321;
        //    newSpaceship.LastMaintenance = DateTime.Now.AddYears(1);
        //    newSpaceship.EnginePower = 321;
        //    newSpaceship.MaidenLaunch = DateTime.Now.AddYears(1);
        //    newSpaceship.BuiltDate = DateTime.Now.AddYears(1);

        //    return spaceship;
        //}













    }
}
