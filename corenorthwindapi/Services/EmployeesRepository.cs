using corenorthwindapi.Data;
using corenorthwindapi.Models;
using Microsoft.EntityFrameworkCore;

namespace corenorthwindapi.Services
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly NorthwindDbContext _context;

        public EmployeesRepository(NorthwindDbContext context)
        {
            this._context = context;
        }


        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetOneAsync(int id)
        {
            return await _context.Employees.Where(x => x.EmployeeId == id).ToListAsync();
        }
    }

}

