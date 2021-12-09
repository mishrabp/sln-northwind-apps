using corenorthwindapi.Data;
using corenorthwindapi.Models;
using Microsoft.EntityFrameworkCore;

namespace corenorthwindapi.Services
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly NorthwindDbContext _context;

        public CustomersRepository(NorthwindDbContext context)
        {
            this._context = context;
        }


        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }


        public async Task<List<Customer>> GetOneAsync(string id)
        {
            return await _context.Customers.Where(x => x.CustomerId.Equals(id)).ToListAsync();
        }

    }
}
