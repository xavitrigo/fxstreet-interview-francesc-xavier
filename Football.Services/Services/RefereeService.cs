using AutoMapper;
using Football.API.Models;
using Football.Database;
using Football.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Services.Services
{
    public class RefereeService : IRefereeService
    {
        private readonly FootballContext _footballContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RefereeService> _logger;

        public RefereeService(
            FootballContext footballContext,
            IMapper mapper,
            ILogger<RefereeService> logger
        )
        {
            _footballContext = footballContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<RefereeDto>> GetAllReferees()
        {
            var Referees = await _footballContext.Referees
                .Select(m => _mapper.Map<RefereeDto>(m))
                .ToListAsync();
            return Referees;
        }

        public async Task<RefereeDto> GetRefereeById(int id)
        {
            var referee = await _footballContext.Referees
                .AsNoTracking() //Detatch the entity so when it's getted, you can updated it
                .FirstOrDefaultAsync(r => r.Id == id);
            return _mapper.Map<RefereeDto>(referee);
        }

        public async Task<RefereeDto> AddReferee(RefereeDto newReferee)
        {
            var parsedReferee = _mapper.Map<Referee>(newReferee);
            parsedReferee.Id = 0; //ID will be setted automatically 

            var refereeInDb = await _footballContext.Referees.AddAsync(parsedReferee);
            var entitiesSaved = await _footballContext.SaveChangesAsync();

            if (entitiesSaved == 1)
            {
                _logger.LogInformation($"Created Referee with ID ${refereeInDb.Entity.Id}");
                return _mapper.Map<RefereeDto>(refereeInDb.Entity);
            }

            _logger.LogError($"Couldn't create Referee with ID ${refereeInDb.Entity.Id}");
            return null;
        }

        public async Task<RefereeDto> UpdateReferee(int id, RefereeDto newReferee)
        {
            var parsedReferee = _mapper.Map<Referee>(newReferee);
            parsedReferee.Id = id; //To make sure the right entity is updated

            var refereeInDb = _footballContext.Referees.Update(parsedReferee).Entity;
            var entitiesSaved = await _footballContext.SaveChangesAsync();

            if (entitiesSaved == 1)
            {
                _logger.LogInformation($"Updated Referee with ID ${refereeInDb.Id}");
                return _mapper.Map<RefereeDto>(refereeInDb);
            }

            _logger.LogError($"Couldn't update Referee with ID ${id}");
            return null;
        }

        public async Task<bool> RefereeExistsInDb(int id) =>
            await _footballContext.Referees.AnyAsync(r => r.Id == id);
    }
}
