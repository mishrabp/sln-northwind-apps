using corenorthwindapi.Models;

namespace corenorthwindapi.Services
{
    public interface ICustomersService
    {
        Task<List<Customer>> GetAllAsync();
        Task<List<Customer>> GetOneAsync(string id);
    }
}
