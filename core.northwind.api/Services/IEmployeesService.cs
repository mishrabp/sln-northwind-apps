using corenorthwindapi.Models;

namespace corenorthwindapi.Services
{
    public interface IEmployeesService
    {
        Task<List<Employee>> GetAllAsync();
        Task<List<Employee>> GetOneAsync(int id);
        Task<int> CreateAsync(Employee entity);
    }
}
