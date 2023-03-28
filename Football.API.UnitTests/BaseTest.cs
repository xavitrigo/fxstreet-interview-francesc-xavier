using Football.API.UnitTests.Fixtures;
using Football.API.UnitTests.Stubs;
using Football.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Text.Json;
using System.Xml;

namespace Football.API.UnitTests
{
    [TestFixture]
    public class BaseTest
    {
        protected FootballContextStub _footballDbStub = GenerateDatabase();
        private static readonly DbContextOptions<FootballContext> _options = 
            new DbContextOptionsBuilder<FootballContext>()
                .UseInMemoryDatabase(databaseName: "football")
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .Options;


        [SetUp]
        public void Init()
        {
            
        }

        [TearDown]
        public void Finish()
        {
            
        }

        protected static FootballContextStub GenerateDatabase()
        {
            var db = new FootballContextStub(_options);
            InitializeData(db);
            return db;
        }

        protected static void InitializeData(FootballContextStub db)
        {
            db.Managers.AddAsync(ManagerFixture.managerInDb);

            db.SaveChanges();
        }

        protected void AreObjectsEquals(object expected, object actual)
        {
            var expectedJson = JsonSerializer.Serialize(expected);
            var actualJson = JsonSerializer.Serialize(actual);
            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}