using corenorthwindapi.Models;

namespace corenorthwindapi.Services
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<List<Customer>> GetOneAsync(string id);
    }
}
