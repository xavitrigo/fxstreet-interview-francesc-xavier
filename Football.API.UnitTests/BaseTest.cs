using Football.API.UnitTests.Mocks;
using Football.Database;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Football.API.UnitTests
{
    public class Tests
    {
        [TestFixture]
        public class BaseTest
        {
            protected FootballContextMock _mockedLogisticDb;

            [SetUp]
            public void Init()
            {
                var options = new DbContextOptionsBuilder<FootballContext>()
                    .UseInMemoryDatabase(databaseName: "football")
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
                    .Options;

                _mockedLogisticDb = new FootballContextMock(options);
            }

            [TearDown]
            public void Finish()
            {

            }
        }
    }
}