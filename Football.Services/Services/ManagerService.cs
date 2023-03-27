using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Football.API.Models;
using Football.Database;
using Football.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Football.Services.Services
{
    public class ManagerService : IManagerService
    {
        private readonly FootballContext _footballContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ManagerService(
            FootballContext footballContext,
            IMapper mapper,
            ILogger<ManagerService> logger
        ) {
            _footballContext = footballContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<ManagerDto>> GetAllManagers()
        {
            var managers = await _footballContext.Managers
                .Select(m => _mapper.Map<ManagerDto>(m))
                .ToListAsync();
            return managers;
        }

        public async Task<ManagerDto> GetManagerById(int id)
        {
            var manager = await _footballContext.Managers
                .AsNoTracking() //Detatch the entity so when it's getted, you can updated it
                .FirstOrDefaultAsync(manager => manager.Id == id);
            return _mapper.Map<ManagerDto>(manager);
        }

        public async Task<ManagerDto> AddManager(ManagerDto newManager)
        {
            var parsedManager = _mapper.Map<Manager>(newManager);
            parsedManager.Id = 0; //ID will be setted automatically 

            var managerInDb = await _footballContext.Managers.AddAsync(parsedManager);
            var entitiesSaved = await _footballContext.SaveChangesAsync();

            if (entitiesSaved == 1)
            {
                _logger.LogInformation($"Created Manager with ID ${managerInDb.Entity.Id}");
                return _mapper.Map<ManagerDto>(managerInDb.Entity);
            }

            _logger.LogError($"Couldn't create Manager with ID ${managerInDb.Entity.Id}");
            return null;
        }

        public async Task<ManagerDto> UpdateManager(int id, ManagerDto newManager)
        {
            var parsedManager = _mapper.Map<Manager>(newManager);
            parsedManager.Id = id; //To make sure the right entity is updated

            var managerInDb = _footballContext.Managers.Update(parsedManager).Entity;
            var entitiesSaved = await _footballContext.SaveChangesAsync();

            if (entitiesSaved == 1)
            {
                _logger.LogInformation($"Updated Manager with ID ${managerInDb.Id}");
                return _mapper.Map<ManagerDto>(managerInDb);
            }

            _logger.LogError($"Couldn't update Manager with ID ${id}");
            return null;
        }

        public async Task<bool> ManagerExistsInDb(int id) => 
            await _footballContext.Managers.AnyAsync(manager => manager.Id == id);
    }
}
