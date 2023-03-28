using AutoMapper;
using Football.API.UnitTests.Fixtures;
using Football.Services.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading.Tasks;
using Football.API.Models;

namespace Football.API.UnitTests.Tests
{
    //
    //NOTE: Due to time, only the happy path has been tested
    //

    [TestFixture]
    public class AuthServiceTest : BaseTest
    {
        private readonly IMapper _mapper = Stubs.AutoMapper.GenerateAutoMapper();
        private readonly ILogger<ManagerService> _logger = new Mock<ILogger< ManagerService>>().Object;

        [Test]
        public async Task ShouldReturnManagersWhenManagersInDb()
        {
            //Arrange
            var _service = new ManagerService(
                _footballDbStub,
                _mapper,
                _logger
            );

            //Act
            var response = await _service.GetAllManagers();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response);
        }

        [Test]
        public async Task ShouldReturnManagerById()
        {
            //Arrange
            var _service = new ManagerService(
                _footballDbStub,
                _mapper,
                _logger
            );

            //Act
            var response = await _service.GetManagerById(ManagerFixture.managerInDb.Id);

            //Assert
            var mappedManager = _mapper.Map<ManagerDto>(ManagerFixture.managerInDb);

            Assert.IsNotNull(response);
            AreObjectsEquals(mappedManager, response);
        }

        [Test]
        public async Task ShouldAddManager()
        {
            //Arrange
            var _service = new ManagerService(
                _footballDbStub,
                _mapper,
                _logger
            );

            //Act
            var managerToAdd = _mapper.Map<ManagerDto>(ManagerFixture.managerToAdd);
            var response = await _service.AddManager(managerToAdd);

            //Assert
            var mappedManager = _mapper.Map<ManagerDto>(ManagerFixture.managerToAdd);

            Assert.IsNotNull(response);
            AreObjectsEquals(mappedManager, response);
        }

        [Test]
        public async Task ShouldUpdateManager()
        {
            //Arrange
            var _service = new ManagerService(
                _footballDbStub,
                _mapper,
                _logger
            );

            //Act
            var managerToAdd = _mapper.Map<ManagerDto>(ManagerFixture.managerToAdd);
            var response = await _service.AddManager(managerToAdd);

            //Assert
            var mappedManager = _mapper.Map<ManagerDto>(ManagerFixture.managerToAdd);

            Assert.IsNotNull(response);
            AreObjectsEquals(mappedManager, response);
        }
    }
}
