using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Football.API.Models;
using Football.Database;

namespace Football.Services.Services
{
    public class ManagerService : IManagerService
    {
        private readonly FootballContext _footballContext;
        private readonly IMapper _mapper;

        public ManagerService(
            FootballContext footballContext,
            IMapper mapper
        ) {
            _footballContext = footballContext;
            _mapper = mapper;
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
            return entitiesSaved == 1 ? _mapper.Map<ManagerDto>(managerInDb.Entity) : null;
        }

        public async Task<ManagerDto> UpdateManager(int id, ManagerDto newManager)
        {
            var parsedManager = _mapper.Map<Manager>(newManager);
            parsedManager.Id = id; //To make sure the right entity is updated

            var managerInDb = _footballContext.Managers.Update(parsedManager).Entity;
            var entitiesSaved = await _footballContext.SaveChangesAsync();
            return entitiesSaved == 1 ? _mapper.Map<ManagerDto>(managerInDb) : null;
        }

        public async Task<bool> ManagerExistsInDb(int id) => 
            await _footballContext.Managers.AnyAsync(manager => manager.Id == id);
    }
}
