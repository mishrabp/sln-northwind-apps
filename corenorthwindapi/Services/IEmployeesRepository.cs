using corenorthwindapi.Models;

namespace corenorthwindapi.Services
{
    public interface IEmployeesRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<List<Employee>> GetOneAsync(int id);
    }
}
