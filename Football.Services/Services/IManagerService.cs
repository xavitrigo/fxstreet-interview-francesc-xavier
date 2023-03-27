using Football.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.Services.Services
{
    public interface IManagerService
    {
        Task<ICollection<ManagerDto>> GetAllManagers();
        Task<ManagerDto> GetManagerById(int id);
        Task<ManagerDto> AddManager(ManagerDto newManager);
        Task<ManagerDto> UpdateManager(int id, ManagerDto newManager);
        Task<bool> ManagerExistsInDb(int id);
    }
}
