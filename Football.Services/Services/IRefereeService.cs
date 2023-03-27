using Football.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.Services.Services
{
    public interface IRefereeService
    {
        Task<ICollection<RefereeDto>> GetAllReferees();
        Task<RefereeDto> GetRefereeById(int id);
        Task<RefereeDto> AddReferee(RefereeDto newReferee);
        Task<RefereeDto> UpdateReferee(int id, RefereeDto newReferee);
        Task<bool> RefereeExistsInDb(int id);
    }
}
